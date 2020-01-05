namespace Languages.Logic.Logics
{
    using System.Collections.Generic;
    using System.Linq;
    using Languages.Data;
    using Languages.Repository;

    /// <summary>
    /// Logic for country.
    /// </summary>
    public class CountryLogic : ILogic<country>
    {
        private IRepository<country> repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryLogic"/> class.
        /// </summary>
        public CountryLogic()
        {
            this.repository = new CountryRepository(Logic.DB);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryLogic"/> class.
        /// </summary>
        /// <param name="ir">Custom repository.</param>
        public CountryLogic(IRepository<country> ir)
        {
            this.repository = ir;
        }

        /// <inheritdoc/>
        public IEnumerable<country> GetAll()
        {
            return this.repository.GetAll().ToList();
        }

        /// <inheritdoc/>
        public country GetOne(int id)
        {
            return this.repository.GetOne(id);
        }

        /// <inheritdoc/>
        public void Insert(country entry)
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
