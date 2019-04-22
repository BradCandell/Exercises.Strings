using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Exercises.Strings.Core {


    /// <summary>
    /// Extension Methods for <see cref="string"/> randomization
    /// </summary>
    public static partial class Extensions {

        private static Random random = new Random((int)DateTime.Now.Ticks);



        /// <summary>
        /// Executes consistent Pre-validation steps before randomizing the specified input <see cref="string"/>.
        /// </summary>
        /// <param name="input"><see cref="string"/> to validate for randomizing</param>
        /// <returns>Validated <see cref="string"/> to randomize</returns>
        private static string PreValidateBeforeRandomizing(string input) {

            // Throw an exception if the input value is null or empty.
            if (string.IsNullOrEmpty(input)) {
                throw new ArgumentNullException("input", "Unable to randomize the specified string - Value is null or empty");
            }

            // Throw an exception if the length of the input string is only a single character.
            if (input.Length == 1) {
                throw new StringRandomizationException(input, "Unable to truly randomize a string that is only 1 character in length");
            }

            // Check for all the same characters
            if (Regex.IsMatch(input, "^(.)\\1{1,}$")) {
                throw new StringRandomizationException(input, "Unable to truly randomize a string that contains all of the same characters");
            }


            return input;

        }

        /// <summary>
        /// Randomizes/arranges the charcters of the input <see cref="string"/> into a new string
        /// </summary>
        /// <param name="input"><see cref="string"/> to Randomize</param>
        /// <returns>Randomized/rearranged version of the input <see cref="string"/>.</returns>
        public static string Randomize1(this string input) {

            // Validate that the string can be properly randomized
            string results = PreValidateBeforeRandomizing(input);
            int length = input.Length;

            // Loop until the results are different than the input. This is especially important
            // when you're dealing with small strings that have more of a chance to collide even 
            // after being randomized.
            while (results == input) {

                StringBuilder result = new StringBuilder(length);
                List<char> characters = new List<char>(input);

                for (int i = 0; i < length; i++) {
                    int next = Extensions.random.Next(0, characters.Count);
                    result.Append(characters[next]);
                    characters.RemoveAt(next);
                }

                results = result.ToString();

            }

            return results;

        }

        /// <summary>
        /// Randomizes/arranges the charcters of the input <see cref="string"/> into a new string
        /// </summary>
        /// <param name="input"><see cref="string"/> to Randomize</param>
        /// <returns>Randomized/rearranged version of the input <see cref="string"/>.</returns>
        public static string Randomize2(this string input) {

            // Validate that the string can be properly randomized
            string results = PreValidateBeforeRandomizing(input);

            while (results == input) {
                results = string.Join("", input.OrderBy(x => Guid.NewGuid()));
            }

            return results;

        }

        /// <summary>
        /// Counts the number of times the specified <see cref="char"/> exists in the input <see cref="string"/>.
        /// </summary>
        /// <param name="input">Input <see cref="string"/></param>
        /// <param name="c">The <see cref="char"/> to search and count</param>
        /// <returns>The number of times that the specified <see cref="char"/> is found within the input <see cref="string"/>.</returns>
        public static int CountOf(this string input, char c) {

            int count = 0;

            if (string.IsNullOrEmpty(input)) {
                return count;
            }
            
            for (int i = 0; i < input.Length; i++) {
                if (input[i] == c) {
                    count++;
                }
            }

            return count;
                
        }


    }
}
