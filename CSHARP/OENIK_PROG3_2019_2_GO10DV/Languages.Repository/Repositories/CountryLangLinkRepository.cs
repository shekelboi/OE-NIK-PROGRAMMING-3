namespace Languages.Repository
{
    using System.Linq;
    using Languages.Data;

    /// <summary>
    /// Repository for the countries.
    /// </summary>
    public class CountryLangLinkRepository : IRepository<country_lang_link>
    {
        private DatabaseEntities db;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryLangLinkRepository"/> class.
        /// </summary>
        /// <param name="provider">Source of the DB context.</param>
        public CountryLangLinkRepository(DatabaseEntities provider)
        {
            this.db = provider;
        }

        /// <inheritdoc/>
        public IQueryable<country_lang_link> GetAll()
        {
            return this.db.country_lang_link.AsQueryable();
        }

        /// <inheritdoc/>
        public country_lang_link GetOne(int id)
        {
            return this.db.country_lang_link.Where(x => x.id == id).First();
        }

        /// <inheritdoc/>
        public void Insert(country_lang_link entry)
        {
            this.db.country_lang_link.Add(entry);
        }

        /// <inheritdoc/>
        public void Modify(int id, int lang_id)
        {
            this.db.country_lang_link.Where(x => x.id == id).First().lang_id = lang_id;
        }

        /// <inheritdoc/>
        public void Remove(int id)
        {
            country_lang_link c = this.db.country_lang_link.Where(x => x.id == id).First();
            this.db.country_lang_link.Remove(c);
        }
    }
}
