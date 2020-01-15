// <copyright file="QLanguageFamilies.cs" company="Barta Zoltán Kevin">
// Copyright (c) Barta Zoltán Kevin. All rights reserved.
// </copyright>

namespace Languages.Logic
{
    using System;

    /// <summary>
    /// For the query.
    /// </summary>
    public class QLanguageFamilies : IEquatable<QLanguageFamilies>
    {
        private string languageName;
        private string langfamName;

        /// <summary>
        /// Initializes a new instance of the <see cref="QLanguageFamilies"/> class.
        /// Constructor of the class.
        /// </summary>
        /// <param name="language_name">Language name.</param>
        /// <param name="langfam_name">Language family name.</param>
        public QLanguageFamilies(string language_name, string langfam_name)
        {
            this.languageName = language_name;
            this.langfamName = langfam_name;
        }

        /// <summary>
        /// Gets language name.
        /// </summary>
        public string Language_name { get => this.languageName; }

        /// <summary>
        /// Gets language family name.
        /// </summary>
        public string Langfam_name { get => this.langfamName; }

        /// <summary>
        /// For checking equality.
        /// </summary>
        /// <param name="other">Other object.</param>
        /// <returns>Whether they are equal.</returns>
        public bool Equals(QLanguageFamilies other)
        {
            return (this.languageName == other.languageName) && (this.Langfam_name == other.langfamName);
        }
    }
}
