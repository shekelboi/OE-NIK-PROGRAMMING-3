namespace Languages.Repository
{
    using System.Linq;
    using Languages.Data;

    /// <summary>
    /// Repository for the countries.
    /// </summary>
    public class CountryRepository : IRepository<country>
    {
        private DatabaseEntities db;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryRepository"/> class.
        /// </summary>
        /// <param name="provider">Source of the DB context.</param>
        public CountryRepository(DatabaseEntities provider)
        {
            this.db = provider;
        }

        /// <inheritdoc/>
        public IQueryable<country> GetAll()
        {
            return this.db.country.AsQueryable();
        }

        /// <inheritdoc/>
        public country GetOne(int id)
        {
            return this.db.country.Where(x => x.id == id).First();
        }

        /// <inheritdoc/>
        public void Insert(country entry)
        {
            this.db.country.Add(entry);
        }

        /// <inheritdoc/>
        public void Modify(int id, int population)
        {
            this.db.country.Where(x => x.id == id).First().population = population;
        }

        /// <inheritdoc/>
        public void Remove(int id)
        {
            country c = this.db.country.Where(x => x.id == id).First();
            this.db.country.Remove(c);
        }
    }
}
