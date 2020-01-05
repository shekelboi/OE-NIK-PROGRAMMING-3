namespace Languages.Logic.Logics
{
    using System.Collections.Generic;
    using System.Linq;
    using Languages.Data;
    using Languages.Repository;

    /// <summary>
    /// Logic for language.
    /// </summary>
    public class LanguageLogic : ILogic<language>/*, ILanguageLogic*/
    {
        private IRepository<language> repository = new LanguageRepository(Logic.DB);

        /// <inheritdoc/>
        public IEnumerable<language> GetAll()
        {
            return this.repository.GetAll().ToList();
        }

        /// <inheritdoc/>
        public void Insert(language entry)
        {
            this.repository.Insert(entry);
        }

        /// <inheritdoc/>
        public void Modify(int id, int value)
        {
            this.repository.Modify(id, value);
        }

        /// <inheritdoc/>
        public void Remove(int id)
        {
            this.repository.Remove(id);
        }

        ///// <inheritdoc/>
        //public IEnumerable<QLanguageFamilies> LanguageFamilies()
        //{
        //    var q = from lang in repository.GetAll() // Throws an error as IQUeryable, so I just used list. https://stackoverflow.com/questions/3571084/only-parameterless-constructors-and-initializers-are-supported-in-linq-to-entiti
        //            join lll in crud.GetAll<langfam_lang_link>().ToList()
        //            on lang.id equals lll.lang_id
        //            join langfam in crud.GetAll<language_family>().ToList()
        //            on lll.langfam_id equals langfam.id
        //            select new QLanguageFamilies(lang.name, langfam.name);
        //    return q;
        //}

        ///// <inheritdoc/>
        //public IEnumerable<QLanguagesByDifficulty> LanguagesByDifficulty()
        //{
        //    var q = from lang in crud.GetAll<language>().ToList()
        //            group lang.name by lang.difficulty
        //            into g_lang
        //            select new QLanguagesByDifficulty(g_lang.Key, g_lang.Count());
        //    return q;
        //}

        ///// <inheritdoc/>
        //public IEnumerable<QOfficialLanguages> OfficialLanguages()
        //{
        //    var q = from lang in crud.GetAll<language>().ToList()
        //            join lll in crud.GetAll<langfam_lang_link>().ToList()
        //            on lang.id equals lll.lang_id
        //            join langfam in crud.GetAll<language_family>().ToList()
        //            on lll.langfam_id equals langfam.id
        //            join cll in crud.GetAll<country_lang_link>().ToList()
        //            on lang.id equals cll.lang_id
        //            join country in crud.GetAll<country>().ToList()
        //            on cll.country_id equals country.id
        //            select new QOfficialLanguages(country.name, lang.name);
        //    return q;
        //}

        ///// <inheritdoc/>
        //public IEnumerable<QNumberOfSpeakers> NumberOfSpeakers()
        //{
        //    var q = from lang in crud.GetAll<language>().ToList()
        //            group lang by lang.difficulty
        //            into g
        //            select new QNumberOfSpeakers(g.Key, g.Select(x => Convert.ToInt64(x.number_of_speakers)).Sum());
        //    return q;
        //}
    }
}