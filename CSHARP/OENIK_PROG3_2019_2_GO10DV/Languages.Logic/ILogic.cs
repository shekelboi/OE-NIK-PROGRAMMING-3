// <copyright file="ILogic.cs" company="Barta Zoltán Kevin">
// Copyright (c) Barta Zoltán Kevin. All rights reserved.
// </copyright>

namespace Languages.Logic
{
    using System.Collections.Generic;

    /// <summary>
    /// For the Business Logic.
    /// </summary>
    public interface ILogic
    {
        /// <summary>
        /// Initializing the database.
        /// </summary>
        void InitDb();

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
        /// Languages and their language families.
        /// </summary>
        /// <returns>Results in a class.</returns>
        IEnumerable<QLanguageFamilies> LanguageFamilies();

        /// <summary>
        /// Number of languages by difficulty.
        /// </summary>
        /// <returns>Results in a class.</returns>
        IEnumerable<QLanguagesByDifficulty> LanguagesByDifficulty();

        /// <summary>
        /// Official languages.
        /// </summary>
        /// <returns>Returns a class.</returns>
        IEnumerable<QOfficialLanguages> OfficialLanguages();

        /// <summary>
        /// Number of speakers by difficulty level.
        /// </summary>
        /// <returns>Returns a class.</returns>
        IEnumerable<QNumberOfSpeakers> NumberOfSpeakers();
    }
}
