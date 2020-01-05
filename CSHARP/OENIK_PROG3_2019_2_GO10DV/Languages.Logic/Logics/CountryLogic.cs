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
        private IRepository<country> repository = new CountryRepository(Logic.DB);

        /// <inheritdoc/>
        public IEnumerable<country> GetAll()
        {
            return this.repository.GetAll().ToList();
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
