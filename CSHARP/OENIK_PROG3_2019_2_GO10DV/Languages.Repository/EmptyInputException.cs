namespace Languages.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
