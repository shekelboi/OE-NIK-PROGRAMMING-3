// <copyright file="LangfamLangLinkLogic.cs" company="Barta Zoltán Kevin">
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
    public class LangfamLangLinkLogic : ILogic<langfam_lang_link>
    {
        private readonly IRepository<langfam_lang_link> repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LangfamLangLinkLogic"/> class.
        /// </summary>
        public LangfamLangLinkLogic()
        {
            this.repository = new LangfamLangLinkRepository(Logic.DB);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LangfamLangLinkLogic"/> class.
        /// </summary>
        /// <param name="ir">Custom repository.</param>
        public LangfamLangLinkLogic(IRepository<langfam_lang_link> ir)
        {
            this.repository = ir;
        }

        /// <inheritdoc/>
        public IEnumerable<langfam_lang_link> GetAll()
        {
            return this.repository.GetAll().ToList();
        }

        /// <inheritdoc/>
        public langfam_lang_link GetOne(int id)
        {
            return this.repository.GetOne(id);
        }

        /// <inheritdoc/>
        public void Insert(langfam_lang_link entry)
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