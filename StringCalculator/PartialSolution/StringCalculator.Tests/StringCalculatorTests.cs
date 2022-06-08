using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StringCalculator.Tests
{
    [TestClass]
    public class StringCalculatorTests
    {
        [TestMethod]
        public void Add_StringEmpty_Returns0()
        {
            var result = StringCalculator.Add(string.Empty);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Add_NumbersSeparatedWithCommas_ReturnsSum()
        {
            var result = StringCalculator.Add("1,1");

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Add_SingleNumer_ReturnsNumber()
        {
            var result = StringCalculator.Add("2");

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Add_FiveNumbersWithCommasAndSpaces_ReturnsSum()
        {
            var result = StringCalculator.Add("5, 5, 5, 5, 5");

            Assert.AreEqual(25, result);
        }

        [TestMethod]
        public void Add_5_5_5_5_Returns20()
        {
            var result = StringCalculator.Add("5, 5, 5, 5");

            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void Add_NumbersSeparatedByNewLines_ReturnsSum()
        {
            var result = StringCalculator.Add("1\n1");

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Add_MultipleSeparetors_ReturnsSum()
        {
            var result = StringCalculator.Add("1\n2, 2");

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Add_EndWith2Separators_ThrowsFormatException()
        {
            Assert.ThrowsException<FormatException>(() => StringCalculator.Add("1,\n"));
        }

        [TestMethod]
        public void Add_CustomSeparatorSpecified_ReturnsSum()
        {
            var result = StringCalculator.Add("//;\n1;2");

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Add_NegativeNumbers_FailAndBadNumbersPartOfExceptionMessage()
        {
            ArgumentException exception = Assert.ThrowsException<ArgumentException>(() => StringCalculator.Add("1,-4"));

            Assert.IsTrue(exception.Message.Contains("-4"));

            exception = Assert.ThrowsException<ArgumentException>(() => StringCalculator.Add("-1,-3"));

            Assert.IsTrue(exception.Message.Contains("-3") && exception.Message.Contains("-1"));
        }

        [TestMethod]
        public void Add_NumberGreaterThan1000_ReturnSumIgnoringThousands()
        {
            var result = StringCalculator.Add("1,1000");

            Assert.AreEqual(1, result);
        }

        
    }
}