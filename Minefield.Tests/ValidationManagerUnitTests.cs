using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minefield.Business.Manager;
using System;

namespace Minefield.Tests
{
    [TestClass]
    public class ValidationManagerUnitTests
    {
        [TestMethod]
        public void IsUserMoveValid_returns_true_on_valid_input()
        {
            ValidationManager validator = new ValidationManager();
            var output = validator.IsUserMoveValid("5 6");
            Assert.AreEqual(true, output);
        }

        [TestMethod]
        public void IsUserMoveValid_returns_false_on_valid_input_zero_zero()
        {
            ValidationManager validator = new ValidationManager();
            var output = validator.IsUserMoveValid("0 0");
            Assert.AreEqual(true, output);
        }

        [TestMethod]
        public void IsUserMoveValid_returns_false_if_negative_input()
        {
            ValidationManager validator = new ValidationManager();
            var output = validator.IsUserMoveValid("-1 5");
            Assert.AreEqual(false, output);

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void IsUserMoveValid_throw_excepton_on_string_input()
        {
            ValidationManager validator = new ValidationManager();
            validator.IsUserMoveValid("some something");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void IsUserMoveValid_throw_excepton_with_invalid_format_input()
        {
            ValidationManager validator = new ValidationManager();
            validator.IsUserMoveValid("5, 6");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void IsUserMoveValid_throw_excepton_with_user_enter_chars()
        {
            ValidationManager validator = new ValidationManager();
            validator.IsUserMoveValid("A B");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void IsUserMoveValid_throw_excepton_with_user_enter_special_chars()
        {
            ValidationManager validator = new ValidationManager();
            validator.IsUserMoveValid("* 2");
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IsUserMoveValid_throw_excepton_if_nospace_added_in_the_input()
        {
            ValidationManager validator = new ValidationManager();
            validator.IsUserMoveValid("16");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void IsUserMoveValid_throw_excepton_on_empty_input()
        {
            ValidationManager validator = new ValidationManager();
            validator.IsUserMoveValid(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void IsUserMoveValid_throw_excepton_on_manyspaces_as_input()
        {
            ValidationManager validator = new ValidationManager();
            validator.IsUserMoveValid("  ");
        }
    }
}
