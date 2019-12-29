// <copyright file="IRepository.cs" company="Barta Zoltán Kevin">
// Copyright (c) Barta Zoltán Kevin. All rights reserved.
// </copyright>

namespace Languages.Repository
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Languages.Data;

    /// <summary>
    /// Interface for business logic.
    /// </summary>
    public interface IRepository<T>
        where T : IEnumerable
    {
        /// <summary>
        /// Initializing the database.
        /// </summary>
        void InitDB();

        /// <summary>
        /// Removes a specific entry from the database.
        /// </summary>
        /// <param name="table">Table to remove the entry from.</param>
        /// <param name="where">Where to remove the entry from.</param>
        /// <param name="value">Value of the entry at that point.</param>
        void Remove(string table, string where, string value);

        /// <summary>
        /// Modifying a value inside a table.
        /// </summary>
        /// <param name="table">Table to modify..</param>
        /// <param name="where">Where you modify the record.</param>
        /// <param name="value">Original value.</param>
        /// <param name="field">Field to modify.</param>
        /// <param name="newValue">New value.</param>
        void Modify(string table, string where, string value, string field, string newValue);

        /// <summary>
        /// Adding a new language family-language link.
        /// </summary>
        /// <param name="lll">Language family-language link entry.</param>
        void AddLangfamLangLink(langfam_lang_link lll);

        /// <summary>
        /// Adding a new country-language link.
        /// </summary>
        /// <param name="cll">Country-language link entry.</param>
        void AddCountryLangLink(country_lang_link cll);

        /// <summary>
        /// Adding a new language family.
        /// </summary>
        /// <param name="lf">Language family entry.</param>
        void AddLanguageFamily(language_family lf);

        /// <summary>
        /// Adding a new language.
        /// </summary>
        /// <param name="l">Language entry.</param>
        void AddLanguage(language l);

        /// <summary>
        /// Adding a new country.
        /// </summary>
        /// <param name="c">Country entry.</param>
        void AddCountry(country c);

        /// <summary>
        /// Listing the names and the populations of countries.
        /// </summary>
        /// <returns>Returns result.</returns>
        T NamesOfCountries();

        /// <summary>
        /// Number of speakers based on the language or the difficulty.
        /// </summary>
        /// <returns>Returns result.</returns>
        string NumberOfSpeakersRollup();

        /// <summary>
        /// Selecting languages and their corresponding language families.
        /// </summary>
        /// <returns>Returns result.</returns>
        string LanguageFamilies();

        /// <summary>
        /// Displaying the official languages of each country.
        /// </summary>
        /// <returns>Returns result.</returns>
        string OfficialLanguages();

        /// <summary>
        /// Number of languages by difficulty.
        /// </summary>
        /// <returns>Returns result.</returns>
        string LanguagesByDifficulty();

        /// <summary>
        /// Displays each of the languages and the number of their speakers in descending order.
        /// </summary>
        /// <returns>Returns result.</returns>
        string NumberOfSpeakers();

        /// <summary>
        /// Listing all the entries.
        /// </summary>
        /// <returns>Returns result.</returns>
        IQueryable<T> GetAll();

        T GetOne(int id);

        void Remove(T entity);

        void Remove(int id);

        void Insert(T entity);
    }
}
