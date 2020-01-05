namespace Languages.Repository
{
    using System.Linq;
    using Languages.Data;

    /// <summary>
    /// Repository for the countries.
    /// </summary>
    public class LangfamLangLinkRepository : IRepository<langfam_lang_link>
    {
        private DatabaseEntities db;

        /// <summary>
        /// Initializes a new instance of the <see cref="LangfamLangLinkRepository"/> class.
        /// </summary>
        /// <param name="provider">Source of the DB context.</param>
        public LangfamLangLinkRepository(DatabaseEntities provider)
        {
            this.db = provider;
        }

        /// <inheritdoc/>
        public IQueryable<langfam_lang_link> GetAll()
        {
            return this.db.langfam_lang_link.AsQueryable();
        }

        /// <inheritdoc/>
        public langfam_lang_link GetOne(int id)
        {
            return this.db.langfam_lang_link.Where(x => x.id == id).First();
        }

        /// <inheritdoc/>
        public void Insert(langfam_lang_link entry)
        {
            this.db.langfam_lang_link.Add(entry);
        }

        /// <inheritdoc/>
        public void Modify(int id, int lang_id)
        {
            this.db.langfam_lang_link.Where(x => x.id == id).First().lang_id = lang_id;
        }

        /// <inheritdoc/>
        public void Remove(int id)
        {
            langfam_lang_link c = this.db.langfam_lang_link.Where(x => x.id == id).First();
            this.db.langfam_lang_link.Remove(c);
        }
    }
}
