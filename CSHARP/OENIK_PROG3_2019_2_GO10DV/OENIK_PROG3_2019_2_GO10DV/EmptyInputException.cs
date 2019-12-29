// <copyright file="EmptyInputException.cs" company="Barta Zoltán Kevin">
// Copyright (c) Barta Zoltán Kevin. All rights reserved.
// </copyright>

namespace OENIK_PROG3_2019_2_GO10DV
{
    using System;

    /// <summary>
    /// Exception for empty input.
    /// </summary>
    public class EmptyInputException : FormatException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmptyInputException"/> class.
        /// Constructor of the class that send the message to the constructor of the format exception.
        /// </summary>
        /// <param name="message">Custom message which has a default.</param>
        public EmptyInputException(string message = "The input was empty.")
            : base(message)
        {
        }
    }
}
