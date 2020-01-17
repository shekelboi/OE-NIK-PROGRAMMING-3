// <copyright file="IsTorF.cs" company="Barta Zoltán Kevin">
// Copyright (c) Barta Zoltán Kevin. All rights reserved.
// </copyright>

namespace Languages.Data
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Checking whether a value is valid.
    /// </summary>
    public class IsTorF : ValidationAttribute
    {
        /// <summary>
        /// Displayed error message.
        /// </summary>
        /// <param name="name">Name of the field.</param>
        /// <returns>Returns an error message.</returns>
        public override string FormatErrorMessage(string name)
        {
            return $"{name}'s value wasn't T or F.";
        }

        /// <summary>
        /// Checks if the value either T or F.
        /// </summary>
        /// <param name="value">Value of the field.</param>
        /// <returns>Returns whether the value is valid.</returns>
        public override bool IsValid(object value)
        {
            return value.ToString().ToUpper() == "T" || value.ToString().ToUpper() == "F";
        }
    }
}