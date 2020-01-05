namespace Languages.Logic.Logics
{
    using System.Collections.Generic;
    using System.Linq;
    using Languages.Data;
    using Languages.Repository;

    /// <summary>
    /// Logic for language.
    /// </summary>
    public class LanguageFamilyLogic : ILogic<language_family>
    {
        private IRepository<language_family> repository = new LanguageFamilyRepository(Logic.DB);

        /// <inheritdoc/>
        public IEnumerable<language_family> GetAll()
        {
            return this.repository.GetAll().ToList();
        }

        /// <inheritdoc/>
        public void Insert(language_family entry)
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