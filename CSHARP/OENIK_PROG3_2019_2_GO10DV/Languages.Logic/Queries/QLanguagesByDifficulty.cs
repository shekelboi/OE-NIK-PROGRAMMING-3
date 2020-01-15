// <copyright file="QLanguagesByDifficulty.cs" company="Barta Zoltán Kevin">
// Copyright (c) Barta Zoltán Kevin. All rights reserved.
// </copyright>

namespace Languages.Logic
{
    using System;

    /// <summary>
    /// For the query.
    /// </summary>
    public class QLanguagesByDifficulty : IEquatable<QLanguagesByDifficulty>
    {
        private string difficulty;
        private int sum;

        /// <summary>
        /// Initializes a new instance of the <see cref="QLanguagesByDifficulty"/> class.
        /// Consturctor of the class.
        /// </summary>
        /// <param name="difficulty">Difficulty of the language.</param>
        /// <param name="sum">Number of languages.</param>
        public QLanguagesByDifficulty(string difficulty, int sum)
        {
            this.difficulty = difficulty;
            this.sum = sum;
        }

        /// <summary>
        /// Gets difficulty of the language.
        /// </summary>
        public string Difficulty { get => this.difficulty; }

        /// <summary>
        /// Gets number of languages.
        /// </summary>
        public int Sum { get => this.sum; }

        /// <summary>
        /// For checking equality.
        /// </summary>
        /// <param name="other">Other object.</param>
        /// <returns>Whether they are equal.</returns>
        public bool Equals(QLanguagesByDifficulty other)
        {
            return (this.difficulty == other.difficulty) && (this.sum == other.sum);
        }
    }
}
