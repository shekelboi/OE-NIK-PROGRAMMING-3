// <copyright file="CountryLangLinkLogic.cs" company="Barta Zoltán Kevin">
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
    public class CountryLangLinkLogic : ILogic<country_lang_link>
    {
        private IRepository<country_lang_link> repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryLangLinkLogic"/> class.
        /// </summary>
        public CountryLangLinkLogic()
        {
            this.repository = new CountryLangLinkRepository(Logic.DB);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryLangLinkLogic"/> class.
        /// </summary>
        /// <param name="ir">Custom repository.</param>
        public CountryLangLinkLogic(IRepository<country_lang_link> ir)
        {
            this.repository = ir;
        }

        /// <inheritdoc/>
        public IEnumerable<country_lang_link> GetAll()
        {
            return this.repository.GetAll().ToList();
        }

        /// <inheritdoc/>
        public country_lang_link GetOne(int id)
        {
            return this.repository.GetOne(id);
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