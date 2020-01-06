// <copyright file="LanguageLogic.cs" company="Barta Zoltán Kevin">
// Copyright (c) Barta Zoltán Kevin. All rights reserved.
// </copyright>

namespace Languages.Logic.Logics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Languages.Data;
    using Languages.Repository;

    /// <summary>
    /// Logic for language.
    /// </summary>
    public class LanguageLogic : ILogic<language>, ILanguageLogic
    {
        private readonly IRepository<language> repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageLogic"/> class.
        /// </summary>
        public LanguageLogic()
        {
            this.repository = new LanguageRepository(Logic.DB);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageLogic"/> class.
        /// </summary>
        /// <param name="ir">Custom repository.</param>
        public LanguageLogic(IRepository<language> ir)
        {
            this.repository = ir;
        }

        /// <inheritdoc/>
        public IEnumerable<language> GetAll()
        {
            return this.repository.GetAll().ToList();
        }

        /// <inheritdoc/>
        public void Insert(language entry)
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

        /// <inheritdoc/>
        public IEnumerable<QLanguageFamilies> LanguageFamilies()
        {
            var q = from lang in new LanguageLogic().GetAll()
                    join lll in new LangfamLangLinkLogic().GetAll()
                    on lang.id equals lll.lang_id
                    join langfam in new LanguageFamilyLogic().GetAll()
                    on lll.langfam_id equals langfam.id
                    select new QLanguageFamilies(lang.name, langfam.name);
            return q.ToList();
        }

        /// <inheritdoc/>
        public IEnumerable<QLanguagesByDifficulty> LanguagesByDifficulty()
        {
            var q = from lang in this.GetAll()
                    group lang.name by lang.difficulty
                    into g_lang
                    select new QLanguagesByDifficulty(g_lang.Key, g_lang.Count());
            return q;
        }

        /// <inheritdoc/>
        public IEnumerable<QOfficialLanguages> OfficialLanguages()
        {
            var q = from lang in this.GetAll()
                    join lll in new LangfamLangLinkLogic().GetAll()
                    on lang.id equals lll.lang_id
                    join langfam in new LanguageFamilyLogic().GetAll()
                    on lll.langfam_id equals langfam.id
                    join cll in new CountryLangLinkLogic().GetAll()
                    on lang.id equals cll.lang_id
                    join country in new CountryLogic().GetAll()
                    on cll.country_id equals country.id
                    select new QOfficialLanguages(country.name, lang.name);
            return q;
        }

        /// <inheritdoc/>
        public IEnumerable<QNumberOfSpeakers> NumberOfSpeakers()
        {
            var q = from lang in new LanguageLogic().GetAll()
                    group lang by lang.difficulty
                    into g
                    select new QNumberOfSpeakers(g.Key, g.Select(x => Convert.ToInt64(x.number_of_speakers)).Sum());
            return q;
        }

        /// <inheritdoc/>
        public language GetOne(int id)
        {
            return this.repository.GetOne(id);
        }
    }
}