using System;

namespace Exercises.Strings.Core {

    /// <summary>
    /// String Randomization Exception
    /// </summary>
    public class StringRandomizationException : Exception {

        /// <summary>
        /// Get the Value of the <see cref="string"/> that caused the randomization exception
        /// </summary>
        public string Value { get; private set; }




        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="message">Message</param>
        public StringRandomizationException(string value, string message) : this(value, message, null) {

        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="innerException">Inner Exception</param>
        public StringRandomizationException(string value, string message, Exception innerException) : base(message, innerException) {
            this.Value = value;
        }



    }
}
