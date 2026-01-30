using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DateValidation.UnitTests
{
    [TestClass]
    public class DateValidatorTests
    {
        [TestMethod]
        [DataRow("12-05-2023", true)]
        [DataRow("01-01-2000", true)]
        public void ValidateStringDate_WithValidDates_ShouldReturnTrue(string date, bool expected)
        {
            var validator = new DateValidator(date);

            var result = validator.ValidateStringDate();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("12-05", false)]
        [DataRow("12-05-2023-01", false)]
        public void ValidateStringDate_WithWrongFormat_ShouldReturnFalse(string date, bool expected)
        {
            var validator = new DateValidator(date);

            var result = validator.ValidateStringDate();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("aa-05-2023", false)]
        [DataRow("12-mm-2023", false)]
        public void ValidateStringDate_WithNonNumericValues_ShouldReturnFalse(string date, bool expected)
        {
            var validator = new DateValidator(date);

            var result = validator.ValidateStringDate();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("32-01-2023", false)]
        [DataRow("12-13-2023", false)]
        [DataRow("12-05-1999", false)]
        public void ValidateStringDate_WithInvalidRanges_ShouldReturnFalse(string date, bool expected)
        {
            var validator = new DateValidator(date);

            var result = validator.ValidateStringDate();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ValidateStringDate_WithNull_ShouldThrowArgumentException()
        {
            var validator = new DateValidator(null);

            Assert.ThrowsException<ArgumentException>(() => validator.ValidateStringDate());
        }
         
    }
}
