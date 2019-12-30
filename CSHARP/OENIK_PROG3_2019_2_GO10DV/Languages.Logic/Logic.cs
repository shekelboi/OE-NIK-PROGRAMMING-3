namespace Languages.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Languages.Data;
    using Languages.Repository;

    /// <summary>
    /// Accessible query methods for the user.
    /// </summary>
    public class Logic : ILogic
    {
        /// <summary>
        /// Instance for calling queries.
        /// </summary>
        private static Queries crud = new Queries();

        /// <summary>
        /// Returns all the tables.
        /// </summary>
        private static IQueryable db { get { return crud.GetAll(); } }

        /// <inheritdoc/>
        public void InitDb()
        {
            crud.InitDB();
        }

        /// <inheritdoc/>
        public void Remove(string table, string where, string value)
        {
            crud.Remove(table, where, value);
        }

        public void Insert<T>(T entity)
        {
            crud.Insert(entity);
        }

        /// <inheritdoc/>
        public void Modify(string table, string where, string value, string field, string newValue)
        {
            crud.Modify(table, where, value, field, newValue);
        }

        /// <inheritdoc/>
        public void AddLangfamLangLink(langfam_lang_link lll)
        {
            crud.AddLangfamLangLink(lll);
        }

        /// <inheritdoc/>
        public void AddCountryLangLink(country_lang_link cll)
        {
            crud.AddCountryLangLink(cll);
        }

        /// <inheritdoc/>
        public void AddLanguageFamily(language_family lf)
        {
            crud.AddLanguageFamily(lf);
        }

        /// <inheritdoc/>
        public void AddLanguage(language l)
        {
            crud.AddLanguage(l);
        }

        /// <inheritdoc/>
        public void AddCountry(country c)
        {
            Logic.crud.AddCountry(c);
        }

        public IQueryable GetAll()
        {
            return crud.GetAll();
        }

        /// <inheritdoc/>
        public IEnumerable<QLanguageFamilies> LanguageFamilies()
        {
            var q = from lang in db.OfType<language>()
                    join lll in db.OfType<langfam_lang_link>()
                    on lang.id equals lll.lang_id
                    join langfam in db.OfType<language_family>()
                    on lll.langfam_id equals langfam.id
                    select new QLanguageFamilies(lang.name, langfam.name);
            return q;
        }

        /// <inheritdoc/>
        public IEnumerable<QLanguagesByDifficulty> LanguagesByDifficulty()
        {
            var q = from lang in db.OfType<language>()
                    group lang.name by lang.difficulty
                    into g_lang
                    select new QLanguagesByDifficulty(g_lang.Key, g_lang.Count());
            return q;
        }

        /// <inheritdoc/>
        public IEnumerable<QOfficialLanguages> OfficialLanguages()
        {
            var q = from lang in db.OfType<language>()
                    join lll in db.OfType<langfam_lang_link>()
                    on lang.id equals lll.lang_id
                    join langfam in db.OfType<language_family>()
                    on lll.langfam_id equals langfam.id
                    join cll in db.OfType<country_lang_link>()
                    on lang.id equals cll.lang_id
                    join country in db.OfType<country>()
                    on cll.country_id equals country.id
                    select new QOfficialLanguages(country.name, lang.name);
            return q;
        }

        /// <inheritdoc/>
        public IEnumerable<QNumberOfSpeakers> NumberOfSpeakers()
        {
            var q = from lang in db.OfType<language>()
                    group lang by lang.difficulty
                    into g
                    select new QNumberOfSpeakers(g.Key, g.Select(x => Convert.ToInt64(x.number_of_speakers)).Sum());
            return q;
        }
    }
}
