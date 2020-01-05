// <copyright file="ILanguageLogic.cs" company="Barta Zoltán Kevin">
// Copyright (c) Barta Zoltán Kevin. All rights reserved.
// </copyright>

namespace Languages.Logic
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for the language logic.
    /// </summary>
    public interface ILanguageLogic
    {
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
