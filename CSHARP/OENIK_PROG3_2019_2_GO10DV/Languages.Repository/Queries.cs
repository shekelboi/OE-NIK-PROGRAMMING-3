namespace Languages.Repository
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Languages.Data;

    /// <summary>
    /// A class for the queries.
    /// </summary>
    public static class Queries
    {
        private static DatabaseEntities db = new DatabaseEntities();

        /// <summary>
        /// Initializing the database by setting it back to the default state.
        /// </summary>
        public static void InitDB()
        {
            db.Database.ExecuteSqlCommand(File.ReadAllText(@"..\..\..\Languages.Data\SQL\Table creation.sql")); // Because of some caching problem sometimes it doesn't work, if that's the case just modify anything in the source and rebuild the solution.
            db.SaveChanges();
        }

        /// <summary>
        /// Removes a specific entry from the database.
        /// </summary>
        /// <param name="table">Table to remove the entry from.</param>
        /// <param name="where">Where to remove the entry from.</param>
        /// <param name="value">Value of the entry at that point.</param>
        public static void Remove(string table, string where, string value)
        {
            db.Database.ExecuteSqlCommand("delete from " + table + " where " + table + "." + where + " = '" + value + "';");
            db.SaveChanges();
        }

        /// <summary>
        /// Modifying a value inside a table.
        /// </summary>
        /// <param name="table">Table to modify..</param>
        /// <param name="where">Where you modify the record.</param>
        /// <param name="value">Original value.</param>
        /// <param name="field">Field to modify.</param>
        /// <param name="newValue">New value.</param>
        public static void Modify(string table, string where, string value, string field, string newValue)
        {
            db.Database.ExecuteSqlCommand("update " + table + " set " + field + " = '" + newValue + "' where " + table + "." + where + " = '" + value + "';");
            db.SaveChanges();
        }

        /// <summary>
        /// Adding a new language family-language link.
        /// </summary>
        /// <param name="lll">Language family-language link entry.</param>
        public static void AddLangfamLangLink(langfam_lang_link lll)
        {
            db.langfam_lang_link.Add(lll);
            db.SaveChanges();
        }

        /// <summary>
        /// Adding a new country-language link.
        /// </summary>
        /// <param name="cll">Coutnry-language link entry.</param>
        public static void AddCountryLangLink(country_lang_link cll)
        {
            db.country_lang_link.Add(cll);
            db.SaveChanges();
        }

        /// <summary>
        /// Adding a new language family.
        /// </summary>
        /// <param name="lf">Language family entry.</param>
        public static void AddLanguageFamily(language_family lf)
        {
            db.language_family.Add(lf);
            db.SaveChanges();
        }

        /// <summary>
        /// Adding a new language.
        /// </summary>
        /// <param name="l">Language entry.</param>
        public static void AddLanguage(language l)
        {
            db.language.Add(l);
            db.SaveChanges();
        }

        /// <summary>
        /// Adding a new country.
        /// </summary>
        /// <param name="c">Country entry.</param>
        public static void AddCountry(country c)
        {
            db.country.Add(c);
            db.SaveChanges();
        }

        /// <summary>
        /// Listing the names and the populations of countries.
        /// </summary>
        /// <returns>Result.</returns>
        public static string NamesOfCountries()
        {
            var q = db.Database.SqlQuery<Items<string, int>>("select name as [A], population as [B] from country;");

            string result = string.Empty;

            foreach (var item in q)
            {
                result += string.Format("{0, 15} {1, 20}", item.A, item.B);
            }

            return result;
        }

        /// <summary>
        /// Number of speakers based on the language or the difficulty.
        /// </summary>
        /// <returns>Result.</returns>
        public static string NumberOfSpeakersRollup()
        {
            string sql = "select language.name as [A], language.difficulty as [B], sum(convert(bigint, language.number_of_speakers))" +
                "as [C] from language group by rollup(language.difficulty, language.name);";
            var q = db.Database.SqlQuery<Items<string, string, long>>(sql);

            string header = string.Format("{0,20} {1,10} {2,20}", "Language", "Difficulty", "No. of speakers");

            string result = header + "\n";

            foreach (var item in q)
            {
                string s = string.Format("{0,20} {1,10} {2,20}", item.A, item.B, item.C) + "\n";
                result += s;
            }

            return result;
        }

        /// <summary>
        /// Selecting languages and their corresponding language families.
        /// </summary>
        /// <returns>Result.</returns>
        public static string LanguageFamilies()
        {
            string sql = "select language.name as [A], language_family.name as [B] " +
                "from language join langfam_lang_link on language.id = langfam_lang_link.lang_id " +
                "join language_family on language_family.id = langfam_lang_link.langfam_id;";
            var q = db.Database.SqlQuery<Items<string, string>>(sql);

            string header = string.Format("{0,20} {1,30}", "Language", "Language family");

            string result = header + "\n";

            foreach (var item in q)
            {
                string s = string.Format("{0,20} {1,30}", item.A, item.B) + "\n";
                result += s;
            }

            return result;
        }

        /// <summary>
        /// Displaying the official languages of each country.
        /// </summary>
        /// <returns>Result.</returns>
        public static string OfficialLanguages()
        {
            string sql = "select concat(country.name, ' has ' + language.name + ' as their official language.') as [A] " +
                "from language join langfam_lang_link on language.id = langfam_lang_link.lang_id " +
                "join language_family on language_family.id = langfam_lang_link.langfam_id " +
                "join country_lang_link on language.id = country_lang_link.lang_id " +
                "join country on country.id = country_lang_link.country_id";
            var q = db.Database.SqlQuery<Items<string>>(sql);

            string header = string.Format("{0,20}", "Official language");

            string result = header + "\n";

            foreach (var item in q)
            {
                string s = string.Format("{0,20}", item.A) + "\n";
                result += s;
            }
            return result;
        }

        /// <summary>
        /// Number of languages by difficulty.
        /// </summary>
        /// <returns>The result.</returns>
        public static string LanguagesByDifficulty()
        {
            string sql = "select language.difficulty as [A], count(language.id) as [B] " +
                "from language group by language.difficulty " +
                "order by [B] desc;";
            var q = db.Database.SqlQuery<Items<string, int>>(sql);

            string header = string.Format("{0,6} {1, 6}", "Difficulty", "No. of speakers");

            string result = header + "\n";

            foreach (var item in q)
            {
                string s = string.Format("{0,6} {1, 6}", item.A, item.B) + "\n";
                result += s;
            }

            return result;
        }

        /// <summary>
        /// Displays each of the languages and the number of their speakers in descending order.
        /// </summary>
        /// <returns>Result.</returns>
        public static string NumberOfSpeakers()
        {
            string sql = "select language.name as [A], sum(country.population) as [B] " +
                "from language " +
                "join langfam_lang_link on language.id = langfam_lang_link.lang_id " +
                "join language_family on language_family.id = langfam_lang_link.langfam_id " +
                "join country_lang_link on language.id = country_lang_link.lang_id " +
                "join country on country.id = country_lang_link.country_id " +
                "group by language.name " +
                "order by sum(country.population) desc;";
            var q = db.Database.SqlQuery<Items<string, int>>(sql);

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
        /// Listing all the entries.
        /// </summary>
        /// <returns>Result.</returns>
        public static string ListAll()
        {
            string result = string.Empty;
            result += "========Countries========" + "\n";

            result += string.Format("{0, 5} {1, 15} {2, 10} {3, 16} {4, 25} {5, 10}", "ID", "Name", "Population", "Capital", "Continent", "Area") + "\n\n";

            foreach (var c in db.country)
            {
                string s = string.Format("{0, 5} {1, 15} {2, 10} {3, 16} {4, 25} {5, 10}", c.id, c.name, c.population, c.capital, c.continent, c.area) + "\n";
                result += s;
            }

            result += "========Language families========" + "\n";

            result += string.Format("{0, 5} {1, 30} {2, 10} {3, 20} {4, 25} {5, 20} {6, 25}", "ID", "Name", "ISO", "No. of speakers", "Rank by no. of speakers", "No. of languages", "Rank by no. of languages") + "\n\n";

            foreach (var l in db.language_family)
            {
                string s = string.Format("{0, 5} {1, 30} {2, 10} {3, 20} {4, 25} {5, 20} {6, 25}", l.id, l.name, l.iso_code, l.number_of_speakers, l.rank_by_no_speakers, l.number_of_languages, l.rank_by_no_languages) + "\n";
                result += s;
            }

            result += "========Languages========" + "\n";

            result += string.Format("{0, 5} {1, 20} {2, 12} {3, 14} {4, 25} {5, 20} {6, 20} {7, 25}", "ID", "Name", "Agglutinative", "No. of tenses", "No. noun decl. cases", "Difficulty", "No. of speakers", "Rank by no. of speakers") + "\n\n";

            foreach (var l in db.language)
            {
                string s = string.Format("{0, 5} {1, 20} {2, 12} {3, 14} {4, 25} {5, 20} {6, 20} {7, 25}", l.id, l.name, l.agglutinative, l.number_of_tenses, l.no_of_noun_declension_cases, l.difficulty, l.number_of_speakers, l.rank_by_no_speakers) + "\n";
                result += s;
            }

            result += "========country_lang_link========" + "\n";

            result += string.Format("{0, 5} {1, 15} {2, 15}", "ID", "country_id", "language_id") + "\n\n";

            foreach (var cl in db.country_lang_link)
            {
                string s = string.Format("{0, 5} {1, 15} {2, 15}", cl.id, cl.country_id, cl.lang_id) + "\n";
                result += s;
            }

            result += "========langfam_lang_link========" + "\n";

            result += string.Format("{0, 5} {1, 15} {2, 20}", "ID", "language_id", "language_family_id") + "\n\n";

            foreach (var ll in db.langfam_lang_link)
            {
                string s = string.Format("{0, 5} {1, 15} {2, 15}", ll.id, ll.lang_id, ll.lang_id) + "\n";
                result += s;
            }

            return result;
        }

        private class Items<T1>
        {
            public T1 A { get; set; }
        }

        private class Items<T1, T2>
        {
            public T1 A { get; set; }

            public T2 B { get; set; }
        }

        private class Items<T1, T2, T3>
        {
            public T1 A { get; set; }

            public T2 B { get; set; }

            public T3 C { get; set; }
        }

        private class Items<T1, T2, T3, T4>
        {
            public T1 A { get; set; }

            public T2 B { get; set; }

            public T3 C { get; set; }

            public T4 D { get; set; }
        }
    }
}
