using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Exercises.Strings.Core;

namespace Exercises.Strings.Core.Tests {

    /// <summary>
    /// Unit Tests for the Exercises String Functions
    /// </summary>
    [TestClass]
    public class StringExtensionTests {

        /// <summary>
        /// Test that the CountOf extension method is able to 
        /// </summary>
        [TestMethod]
        public void Test_Extensions_String_CountOf() {

            string nullValueString = null;


            Assert.AreEqual<int>(0, nullValueString.CountOf('c'));
            Assert.AreEqual<int>(0, "".CountOf('c'));
            Assert.AreEqual<int>(1, "C".CountOf('C'));
            Assert.AreEqual<int>(0, "Brad Candell".CountOf('b'));
            Assert.AreEqual<int>(1, "Brad Candell".CountOf('B'));
            Assert.AreEqual<int>(1, "Brad Candell".CountOf('r'));
            Assert.AreEqual<int>(1, "Brad Candell".CountOf(' '));
            Assert.AreEqual<int>(2, "Brad Candell".CountOf('a'));
            Assert.AreEqual<int>(2, "Brad Candell".CountOf('d'));
            Assert.AreEqual<int>(5, "c1c2c3c4c5a5a5".CountOf('c'));
            Assert.AreEqual<int>(3, "c1c2c3c4c5a5a5".CountOf('5'));

        }

        /// <summary>
        /// Test that an Argument Null Exception is thrown when trying to randomize a Null input string with the Randomize1 function
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Extensions_String_Randomize1_Invalid_Null() {

            // Arrange
            string input = null;


            // Act
            try {
                string results = input.Randomize1();
                Assert.Fail("Expected an Argument Null Exception - Null Input");
            }
            catch (ArgumentNullException ex) {
                throw ex;
            }

        }

        /// <summary>
        /// Test that an Argument Null Exception is thrown when trying to randomize an empty input string with the Randomize1 function
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Extensions_String_Randomize1_Invalid_Empty() {

            // Arrange
            string input = "";


            // Act
            try {
                string results = input.Randomize1();
                Assert.Fail("Expected an Argument Null Exception - Empty Input");
            }
            catch (ArgumentNullException ex) {
                throw ex;
            }

        }

        /// <summary>
        /// Test that a <see cref="StringRandomizationException"/> is thrown when attempting to randomize a single character string with the Randomize1 function
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(StringRandomizationException))]
        public void Test_Extensions_String_Randomize1_Invalid_Length() {

            // Arrange
            string input = "P";


            // Act
            try {
                string results = input.Randomize1();
                Assert.Fail("Expected a String Randomization Exception when the input string is only a single character");
            }
            catch (StringRandomizationException ex) {
                Assert.IsTrue(ex.Message.Contains("1 character in length"));
                Assert.AreEqual("P", ex.Value);
                throw ex;
            }


        }

        /// <summary>
        /// Test that a <see cref="StringRandomizationException"/> is thrown when attempting to randomize a string that contains all of the same characters using the Randomize1 function
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(StringRandomizationException))]
        public void Test_Extensions_String_Randomize1_Invalid_Characters() {

            // Arrange
            string input = "cccccccccc";

            
            // Act
            try {
                string results = input.Randomize1();
                Assert.Fail("Expected a String Randomization Exception when the string contains all the same character");
            }
            catch (StringRandomizationException ex) {
                Assert.IsTrue(ex.Message.Contains("same characters"));
                Assert.AreEqual("cccccccccc", ex.Value);
                throw ex;
            }
        }

        /// <summary>
        /// Test that a <see cref="string"/> can be randomized/jumbled using the Randomize1 extension method
        /// </summary>
        [TestMethod]
        public void Test_Extensions_String_Randomize1() {

            // Arrange
            string test1 = "Brad Candell";
            string test2 = "BRAD";
            string test3 = "PE PE";
            string test4 = "This is a test";
            string test5 = "PC";

            // Act
            string result1 = test1.Randomize1();
            string result1a = test1.Randomize1();
            string result1b = test1.Randomize1();
            string result1c = test1.Randomize1();
            string result2 = test2.Randomize1();
            string result3 = test3.Randomize1();
            string result4 = test4.Randomize1();
            string result5 = test5.Randomize1();


            // Brad Candell
            Assert.AreNotEqual<string>("Brad Candell", result1);
            Assert.AreEqual<int>(12, result1.Length);
            Assert.AreEqual<int>(1, result1.CountOf('B'));
            Assert.AreEqual<int>(1, result1.CountOf('r'));
            Assert.AreEqual<int>(2, result1.CountOf('a'));
            Assert.AreEqual<int>(2, result1.CountOf('d'));
            Assert.AreEqual<int>(1, result1.CountOf(' '));
            Assert.AreEqual<int>(1, result1.CountOf('C'));
            Assert.AreEqual<int>(1, result1.CountOf('n'));
            Assert.AreEqual<int>(1, result1.CountOf('e'));
            Assert.AreEqual<int>(2, result1.CountOf('l'));

            Assert.AreNotEqual<string>(result1, result1a);
            Assert.AreNotEqual<string>(result1, result1b);
            Assert.AreNotEqual<string>(result1, result1c);
            Assert.AreNotEqual<string>(result1a, result1b);
            Assert.AreNotEqual<string>(result1a, result1c);

            // BRAD
            Assert.AreNotEqual<string>("BRAD", result2);
            Assert.AreEqual<int>(4, result2.Length);
            Assert.AreEqual<int>(1, result2.CountOf('B'));
            Assert.AreEqual<int>(1, result2.CountOf('R'));
            Assert.AreEqual<int>(1, result2.CountOf('A'));
            Assert.AreEqual<int>(1, result2.CountOf('D'));

            // PE PE
            Assert.AreNotEqual<string>("PE PE", result3);
            Assert.AreEqual<int>(5, result3.Length);
            Assert.AreEqual<int>(2, result3.CountOf('P'));
            Assert.AreEqual<int>(2, result3.CountOf('E'));
            Assert.AreEqual<int>(1, result3.CountOf(' '));

            // This is a test
            Assert.AreNotEqual<string>("This is a test", result4);
            Assert.AreEqual<int>(14, result4.Length);
            Assert.AreEqual<int>(1, result4.CountOf('T'));
            Assert.AreEqual<int>(1, result4.CountOf('h'));
            Assert.AreEqual<int>(2, result4.CountOf('i'));
            Assert.AreEqual<int>(3, result4.CountOf('s'));
            Assert.AreEqual<int>(3, result4.CountOf(' '));
            Assert.AreEqual<int>(1, result4.CountOf('a'));
            Assert.AreEqual<int>(1, result4.CountOf('e'));
            Assert.AreEqual<int>(2, result4.CountOf('t'));


            // PC
            Assert.AreNotEqual<string>("PC", result5);
            Assert.AreEqual<string>("CP", result5);
            Assert.AreEqual<int>(2, result5.Length);
            Assert.AreEqual<int>(1, result5.CountOf('P'));
            Assert.AreEqual<int>(1, result5.CountOf('C'));

        }

        /// <summary>
        /// Test that an Argument Null Exception is thrown when trying to randomize a Null input string with the Randomize2 function
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Extensions_String_Randomize2_Invalid_Null() {

            // Arrange
            string input = null;


            // Act
            try {
                string results = input.Randomize2();
                Assert.Fail("Expected an Argument Null Exception - Null Input");
            }
            catch (ArgumentNullException ex) {
                throw ex;
            }

        }

        /// <summary>
        /// Test that an Argument Null Exception is thrown when trying to randomize an empty input string with the Randomize2 function
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Extensions_String_Randomize2_Invalid_Empty() {

            // Arrange
            string input = "";


            // Act
            try {
                string results = input.Randomize2();
                Assert.Fail("Expected an Argument Null Exception - Empty Input");
            }
            catch (ArgumentNullException ex) {
                throw ex;
            }

        }

        /// <summary>
        /// Test that a <see cref="StringRandomizationException"/> is thrown when attempting to randomize a single character string with the Randomize2 function
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(StringRandomizationException))]
        public void Test_Extensions_String_Randomize2_Invalid_Length() {

            // Arrange
            string input = "P";


            // Act
            try {
                string results = input.Randomize2();
                Assert.Fail("Expected a String Randomization Exception when the input string is only a single character");
            }
            catch (StringRandomizationException ex) {
                Assert.IsTrue(ex.Message.Contains("1 character in length"));
                Assert.AreEqual("P", ex.Value);
                throw ex;
            }


        }

        /// <summary>
        /// Test that a <see cref="StringRandomizationException"/> is thrown when attempting to randomize a string that contains all of the same characters using the Randomize2 function
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(StringRandomizationException))]
        public void Test_Extensions_String_Randomize2_Invalid_Characters() {

            // Arrange
            string input = "cccccccccc";


            // Act
            try {
                string results = input.Randomize2();
                Assert.Fail("Expected a String Randomization Exception when the string contains all the same character");
            }
            catch (StringRandomizationException ex) {
                Assert.IsTrue(ex.Message.Contains("same characters"));
                Assert.AreEqual("cccccccccc", ex.Value);
                throw ex;
            }
        }

        /// <summary>
        /// Test that a <see cref="string"/> can be randomized/jumbled using the Randomize2 extension method
        /// </summary>
        [TestMethod]
        public void Test_Extensions_String_Randomize2() {

            // Arrange
            string test1 = "Brad Candell";
            string test2 = "BRAD";
            string test3 = "PE PE";
            string test4 = "This is a test";
            string test5 = "PC";

            // Act
            string result1 = test1.Randomize2();
            string result1a = test1.Randomize2();
            string result1b = test1.Randomize2();
            string result1c = test1.Randomize2();
            string result2 = test2.Randomize2();
            string result3 = test3.Randomize2();
            string result4 = test4.Randomize2();
            string result5 = test5.Randomize2();


            // Brad Candell
            Assert.AreNotEqual<string>("Brad Candell", result1);
            Assert.AreEqual<int>(12, result1.Length);
            Assert.AreEqual<int>(1, result1.CountOf('B'));
            Assert.AreEqual<int>(1, result1.CountOf('r'));
            Assert.AreEqual<int>(2, result1.CountOf('a'));
            Assert.AreEqual<int>(2, result1.CountOf('d'));
            Assert.AreEqual<int>(1, result1.CountOf(' '));
            Assert.AreEqual<int>(1, result1.CountOf('C'));
            Assert.AreEqual<int>(1, result1.CountOf('n'));
            Assert.AreEqual<int>(1, result1.CountOf('e'));
            Assert.AreEqual<int>(2, result1.CountOf('l'));

            Assert.AreNotEqual<string>(result1, result1a);
            Assert.AreNotEqual<string>(result1, result1b);
            Assert.AreNotEqual<string>(result1, result1c);
            Assert.AreNotEqual<string>(result1a, result1b);
            Assert.AreNotEqual<string>(result1a, result1c);


            // BRAD
            Assert.AreNotEqual<string>("BRAD", result2);
            Assert.AreEqual<int>(4, result2.Length);
            Assert.AreEqual<int>(1, result2.CountOf('B'));
            Assert.AreEqual<int>(1, result2.CountOf('R'));
            Assert.AreEqual<int>(1, result2.CountOf('A'));
            Assert.AreEqual<int>(1, result2.CountOf('D'));

            // PE PE
            Assert.AreNotEqual<string>("PE PE", result3);
            Assert.AreEqual<int>(5, result3.Length);
            Assert.AreEqual<int>(2, result3.CountOf('P'));
            Assert.AreEqual<int>(2, result3.CountOf('E'));
            Assert.AreEqual<int>(1, result3.CountOf(' '));

            // This is a test
            Assert.AreNotEqual<string>("This is a test", result4);
            Assert.AreEqual<int>(14, result4.Length);
            Assert.AreEqual<int>(1, result4.CountOf('T'));
            Assert.AreEqual<int>(1, result4.CountOf('h'));
            Assert.AreEqual<int>(2, result4.CountOf('i'));
            Assert.AreEqual<int>(3, result4.CountOf('s'));
            Assert.AreEqual<int>(3, result4.CountOf(' '));
            Assert.AreEqual<int>(1, result4.CountOf('a'));
            Assert.AreEqual<int>(1, result4.CountOf('e'));
            Assert.AreEqual<int>(2, result4.CountOf('t'));


            // PC
            Assert.AreNotEqual<string>("PC", result5);
            Assert.AreEqual<string>("CP", result5);
            Assert.AreEqual<int>(2, result5.Length);
            Assert.AreEqual<int>(1, result5.CountOf('P'));
            Assert.AreEqual<int>(1, result5.CountOf('C'));

        }

    }
}
