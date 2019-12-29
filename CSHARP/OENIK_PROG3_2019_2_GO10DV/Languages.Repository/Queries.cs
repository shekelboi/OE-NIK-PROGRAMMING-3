// <copyright file="Queries.cs" company="Barta Zoltán Kevin">
// Copyright (c) Barta Zoltán Kevin. All rights reserved.
// </copyright>

namespace Languages.Repository
{
    using System.IO;
    using System.Linq;
    using Languages.Data;
    using System.Collections.Generic;

    /// <summary>
    /// A class for the queries.
    /// </summary>
    public class Queries
    {
        /// <summary>
        /// New database entity.
        /// </summary>
        private DatabaseEntities db = new DatabaseEntities();

        public IQueryable GetAll()
        {
            List<object> l = new List<object>();
            l.AddRange(this.db.country.ToList());
            l.AddRange(this.db.country_lang_link.ToList());
            l.AddRange(this.db.langfam_lang_link.ToList());
            l.AddRange(this.db.language.ToList());
            l.AddRange(this.db.language_family.ToList());

            return l.AsQueryable();
        }

        /// <inheritdoc/>
        public void InitDB()
        {
            DatabaseEntities db = new DatabaseEntities();
            this.db.Database.ExecuteSqlCommand(File.ReadAllText(@"..\..\..\Languages.Data\SQL\Table creation.sql")); // Because of some caching problem sometimes it doesn't work, if that's the case just modify anything in the source and rebuild the solution.
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void Remove(string table, string where, string value)
        {
            this.db.Database.ExecuteSqlCommand("delete from " + table + " where " + table + "." + where + " = '" + value + "';");
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void Modify(string table, string where, string value, string field, string newValue)
        {
            this.db.Database.ExecuteSqlCommand("update " + table + " set " + field + " = '" + newValue + "' where " + table + "." + where + " = '" + value + "';");
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void AddLangfamLangLink(langfam_lang_link lll)
        {
            this.db.langfam_lang_link.Add(lll);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void AddCountryLangLink(country_lang_link cll)
        {
            this.db.country_lang_link.Add(cll);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void AddLanguageFamily(language_family lf)
        {
            this.db.language_family.Add(lf);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void AddLanguage(language l)
        {
            this.db.language.Add(l);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void AddCountry(country c)
        {
            this.db.country.Add(c);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public IQueryable NamesOfCountries()
        {
            return db.country.AsQueryable();
        }

        // NEM KELL
        ///// <inheritdoc/>
        //public string NumberOfSpeakersRollup()
        //{
        //    string sql = "select language.name as [A], language.difficulty as [B], sum(convert(bigint, language.number_of_speakers))" +
        //        "as [C] from language group by rollup(language.difficulty, language.name);";
        //    var q = this.db.Database.SqlQuery<Items<string, string, long>>(sql);

        //    string header = string.Format("{0,20} {1,10} {2,20}", "Language", "Difficulty", "No. of speakers");

        //    string result = header + "\n";

        //    foreach (var item in q)
        //    {
        //        string s = string.Format("{0,20} {1,10} {2,20}", item.A, item.B, item.C) + "\n";
        //        result += s;
        //    }

        //    return result;
        //}

        /// <inheritdoc/>
        public string LanguageFamilies()
        {
            string sql = "select language.name as [A], language_family.name as [B] " +
                "from language join langfam_lang_link on language.id = langfam_lang_link.lang_id " +
                "join language_family on language_family.id = langfam_lang_link.langfam_id;";
            var q = this.db.Database.SqlQuery<Items<string, string>>(sql);

            string header = string.Format("{0,20} {1,30}", "Language", "Language family");

            string result = header + "\n";

            foreach (var item in q)
            {
                string s = string.Format("{0,20} {1,30}", item.A, item.B) + "\n";
                result += s;
            }

            return result;
        }

        /// <inheritdoc/>
        public string OfficialLanguages()
        {
            string sql = "select concat(country.name, ' has ' + language.name + ' as their official language.') as [A] " +
                "from language join langfam_lang_link on language.id = langfam_lang_link.lang_id " +
                "join language_family on language_family.id = langfam_lang_link.langfam_id " +
                "join country_lang_link on language.id = country_lang_link.lang_id " +
                "join country on country.id = country_lang_link.country_id";
            var q = this.db.Database.SqlQuery<Items<string>>(sql);

            string header = string.Format("{0,20}", "Official language");

            string result = header + "\n";

            foreach (var item in q)
            {
                string s = string.Format("{0,20}", item.A) + "\n";
                result += s;
            }

            return result;
        }

        /// <inheritdoc/>
        public string LanguagesByDifficulty()
        {
            string sql = "select language.difficulty as [A], count(language.id) as [B] " +
                "from language group by language.difficulty " +
                "order by [B] desc;";
            var q = this.db.Database.SqlQuery<Items<string, int>>(sql);

            string header = string.Format("{0,6} {1, 6}", "Difficulty", "No. of speakers");

            string result = header + "\n";

            foreach (var item in q)
            {
                string s = string.Format("{0,6} {1, 6}", item.A, item.B) + "\n";
                result += s;
            }

            return result;
        }

        /// <inheritdoc/>
        public string NumberOfSpeakers()
        {
            string sql = "select language.name as [A], sum(country.population) as [B] " +
                "from language " +
                "join langfam_lang_link on language.id = langfam_lang_link.lang_id " +
                "join language_family on language_family.id = langfam_lang_link.langfam_id " +
                "join country_lang_link on language.id = country_lang_link.lang_id " +
                "join country on country.id = country_lang_link.country_id " +
                "group by language.name " +
                "order by sum(country.population) desc;";

            var q = this.db.Database.SqlQuery<Items<string, int>>(sql);

            string header = string.Format("{0,20} {1, 20}", "Language", "Speakers");

            string result = header + "\n";

            foreach (var item in q)
            {
                string s = string.Format("{0,20} {1, 20}", item.A, item.B) + "\n";
                result += s;
            }

            return result;
        }

        /// <summary>
        /// Class for 4 types.
        /// </summary>
        /// <typeparam name="T1">Type 1.</typeparam>
        private class Items<T1>
        {
            /// <summary>
            /// Gets or sets type A.
            /// </summary>
            public T1 A { get; set; }
        }

        /// <summary>
        /// Class for 4 types.
        /// </summary>
        /// <typeparam name="T1">Type 1.</typeparam>
        /// <typeparam name="T2">Type 2.</typeparam>
        private class Items<T1, T2>
        {
            /// <summary>
            /// Gets or sets type A.
            /// </summary>
            public T1 A { get; set; }

            /// <summary>
            /// Gets or sets type B.
            /// </summary>
            public T2 B { get; set; }
        }

        /// <summary>
        /// Class for 4 types.
        /// </summary>
        /// <typeparam name="T1">Type 1.</typeparam>
        /// <typeparam name="T2">Type 2.</typeparam>
        /// <typeparam name="T3">Type 3.</typeparam>
        private class Items<T1, T2, T3>
        {
            /// <summary>
            /// Gets or sets type A.
            /// </summary>
            public T1 A { get; set; }

            /// <summary>
            /// Gets or sets type B.
            /// </summary>
            public T2 B { get; set; }

            /// <summary>
            /// Gets or sets type C.
            /// </summary>
            public T3 C { get; set; }
        }

        /// <summary>
        /// Class for 4 types.
        /// </summary>
        /// <typeparam name="T1">Type 1.</typeparam>
        /// <typeparam name="T2">Type 2.</typeparam>
        /// <typeparam name="T3">Type 3.</typeparam>
        /// <typeparam name="T4">Type 4.</typeparam>
        private class Items<T1, T2, T3, T4>
        {
            /// <summary>
            /// Gets or sets type A.
            /// </summary>
            public T1 A { get; set; }

            /// <summary>
            /// Gets or sets type B.
            /// </summary>
            public T2 B { get; set; }

            /// <summary>
            /// Gets or sets type C.
            /// </summary>
            public T3 C { get; set; }

            /// <summary>
            /// Gets or sets type D.
            /// </summary>
            public T4 D { get; set; }
        }
    }
}
