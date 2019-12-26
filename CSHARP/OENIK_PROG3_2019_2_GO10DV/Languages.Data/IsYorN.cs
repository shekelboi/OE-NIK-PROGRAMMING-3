// <copyright file="IsYorN.cs" company="Barta Zoltán Kevin">
// Copyright (c) Barta Zoltán Kevin. All rights reserved.
// </copyright>

namespace Languages.Data
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Checking whether a value is valid.
    /// </summary>
    public class IsYorN : ValidationAttribute
    {
        /// <summary>
        /// Displayed error message.
        /// </summary>
        /// <param name="name">Name of the field.</param>
        /// <returns>Returns an error message.</returns>
        public override string FormatErrorMessage(string name)
        {
            return $"{name}'s value wasn't Y or N.";
        }

        /// <summary>
        /// Checks if the value either Y or N.
        /// </summary>
        /// <param name="value">Value of the field.</param>
        /// <returns>Returns whether the value is valid.</returns>
        public override bool IsValid(object value)
        {
            return (string)value == "Y" || (string)value == "N";
        }
    }
}