// <copyright file="LanguageRepository.cs" company="Barta Zoltán Kevin">
// Copyright (c) Barta Zoltán Kevin. All rights reserved.
// </copyright>

namespace Languages.Repository
{
    using System.Linq;
    using Languages.Data;

    /// <summary>
    /// Repository for the countries.
    /// </summary>
    public class LanguageRepository : IRepository<language>
    {
        private readonly DatabaseEntities db;

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageRepository"/> class.
        /// </summary>
        /// <param name="provider">Source of the DB context.</param>
        public LanguageRepository(DatabaseEntities provider)
        {
            this.db = provider;
        }

        /// <inheritdoc/>
        public IQueryable<language> GetAll()
        {
            return this.db.language.AsQueryable();
        }

        /// <inheritdoc/>
        public language GetOne(int id)
        {
            return this.db.language.Where(x => x.id == id).First();
        }

        /// <inheritdoc/>
        public void Insert(language entry)
        {
            this.db.language.Add(entry);
        }

        /// <inheritdoc/>
        public void Modify(int id, int no_speakers)
        {
            this.db.language.Where(x => x.id == id).First().number_of_speakers = no_speakers;
        }

        /// <inheritdoc/>
        public void Remove(int id)
        {
            language c = this.db.language.Where(x => x.id == id).First();
            this.db.language.Remove(c);
        }
    }
}
