// <copyright file="LanguageFamilyRepository.cs" company="Barta Zoltán Kevin">
// Copyright (c) Barta Zoltán Kevin. All rights reserved.
// </copyright>

namespace Languages.Repository
{
    using System.Linq;
    using Languages.Data;

    /// <summary>
    /// Repository for the countries.
    /// </summary>
    public class LanguageFamilyRepository : IRepository<language_family>
    {
        private readonly DatabaseEntities db;

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageFamilyRepository"/> class.
        /// </summary>
        /// <param name="provider">Source of the DB context.</param>
        public LanguageFamilyRepository(DatabaseEntities provider)
        {
            this.db = provider;
        }

        /// <inheritdoc/>
        public IQueryable<language_family> GetAll()
        {
            return this.db.language_family.AsQueryable();
        }

        /// <inheritdoc/>
        public language_family GetOne(int id)
        {
            return this.db.language_family.Where(x => x.id == id).First();
        }

        /// <inheritdoc/>
        public void Insert(language_family entry)
        {
            this.db.language_family.Add(entry);
        }

        /// <inheritdoc/>
        public void Modify(int id, int no_speakers)
        {
            this.db.language_family.Where(x => x.id == id).First().number_of_speakers = no_speakers;
        }

        /// <inheritdoc/>
        public void Remove(int id)
        {
            language_family c = this.db.language_family.Where(x => x.id == id).First();
            this.db.language_family.Remove(c);
        }
    }
}
