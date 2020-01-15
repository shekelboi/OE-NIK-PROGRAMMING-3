// <copyright file="QNumberOfSpeakers.cs" company="Barta Zoltán Kevin">
// Copyright (c) Barta Zoltán Kevin. All rights reserved.
// </copyright>

namespace Languages.Logic
{
    /// <summary>
    /// Class for number of speakers.
    /// </summary>
    public class QNumberOfSpeakers
    {
        private readonly string difficulty;
        private readonly long numberOfSpeakers;

        /// <summary>
        /// Initializes a new instance of the <see cref="QNumberOfSpeakers"/> class.
        /// Constructor for the class.
        /// </summary>
        /// <param name="difficulty">Name of the language.</param>
        /// <param name="numberOfSpeakers">Number of speakers of the language.</param>
        public QNumberOfSpeakers(string difficulty, long numberOfSpeakers)
        {
            this.difficulty = difficulty;
            this.numberOfSpeakers = numberOfSpeakers;
        }

        /// <summary>
        /// Gets the name of the language.
        /// </summary>
        public string Difficulty { get => this.difficulty; }

        /// <summary>
        /// Gets the number of speakers of the language.
        /// </summary>
        public long NumberOfSpeakers { get => this.numberOfSpeakers; }
    }
}
