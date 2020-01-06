// <copyright file="LanguageFamilyLogic.cs" company="Barta Zoltán Kevin">
// Copyright (c) Barta Zoltán Kevin. All rights reserved.
// </copyright>

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
        private readonly IRepository<language_family> repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageFamilyLogic"/> class.
        /// </summary>
        public LanguageFamilyLogic()
        {
            this.repository = new LanguageFamilyRepository(Logic.DB);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageFamilyLogic"/> class.
        /// </summary>
        /// <param name="ir">Custom repository.</param>
        public LanguageFamilyLogic(IRepository<language_family> ir)
        {
            this.repository = ir;
        }

        /// <inheritdoc/>
        public IEnumerable<language_family> GetAll()
        {
            return this.repository.GetAll().ToList();
        }

        /// <inheritdoc/>
        public language_family GetOne(int id)
        {
            return this.repository.GetOne(id);
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