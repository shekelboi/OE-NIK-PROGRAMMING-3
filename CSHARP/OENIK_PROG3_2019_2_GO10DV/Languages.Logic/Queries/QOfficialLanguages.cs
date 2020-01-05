// <copyright file="QOfficialLanguages.cs" company="Barta Zoltán Kevin">
// Copyright (c) Barta Zoltán Kevin. All rights reserved.
// </copyright>

namespace Languages.Logic
{
    /// <summary>
    /// Official languages class.
    /// </summary>
    public class QOfficialLanguages
    {
        private string country;
        private string language;

        /// <summary>
        /// Initializes a new instance of the <see cref="QOfficialLanguages"/> class.
        /// Constructor of the class.
        /// </summary>
        /// <param name="country">Name of the country.</param>
        /// <param name="language">Name of the language.</param>
        public QOfficialLanguages(string country, string language)
        {
            this.country = country;
            this.language = language;
        }

        /// <summary>
        /// Gets the name of the country.
        /// </summary>
        public string Country { get => this.country; }

        /// <summary>
        /// Gets the name of the language.
        /// </summary>
        public string Language { get => this.language; }
    }
}
