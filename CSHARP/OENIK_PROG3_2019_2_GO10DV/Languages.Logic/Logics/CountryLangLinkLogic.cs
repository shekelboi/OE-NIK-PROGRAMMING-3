namespace Languages.Logic.Logics
{
    using System.Collections.Generic;
    using Languages.Data;
    using Languages.Repository;
    using System.Linq;

    /// <summary>
    /// Logic for language.
    /// </summary>
    public class CountryLangLinkLogic : ILogic<country_lang_link>
    {
        private IRepository<country_lang_link> repository = new CountryLangLinkRepository(Logic.DB);

        /// <inheritdoc/>
        public IEnumerable<country_lang_link> GetAll()
        {
            return this.repository.GetAll().ToList();
        }

        /// <inheritdoc/>
        public void Insert(country_lang_link entry)
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
    }
}