using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StringCalculator.Tests
{
    [TestClass]
    public class StringCalculatorTests
    {
        [TestMethod]
        public void Add_ShouldReturn0_When_StringEmpty()
        {
            var result = StringCalculator.Add(string.Empty);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Add_ShouldReturn2_When_1_1()
        {
            var result = StringCalculator.Add("1,1");

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Add_ShouldReturn2_When_2()
        {
            var result = StringCalculator.Add("2");

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Add_ShouldReturn25_When_5_5_5_5_5()
        {
            var result = StringCalculator.Add("5, 5, 5, 5, 5");

            Assert.AreEqual(25, result);
        }

        [TestMethod]
        public void Add_ShouldReturn25_When_5_5_5_5()
        {
            var result = StringCalculator.Add("5, 5, 5, 5");

            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void Add_ShouldReturn2_When_1_1_with_new_lines()
        {
            var result = StringCalculator.Add("1\n1");

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Add_ShouldReturn5_When_1_2_2_with_different_separators()
        {
            var result = StringCalculator.Add("1\n2, 2");

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Add_Should_Fail_When_End_with_2_Separators()
        {
            Assert.ThrowsException<FormatException>(() => StringCalculator.Add("1,\n"));
        }

        [TestMethod]
        public void Add_Should_Sum_When_Custom_Separator_Specified()
        {
            var result = StringCalculator.Add("//;\n1;2");

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Add_Should_Fail_When_Negative_Numbers()
        {
            ArgumentException exception = Assert.ThrowsException<ArgumentException>(() => StringCalculator.Add("1,-4"));

            Assert.IsTrue(exception.Message.Contains("-4"));

            exception = Assert.ThrowsException<ArgumentException>(() => StringCalculator.Add("-1,-3"));

            Assert.IsTrue(exception.Message.Contains("-3") && exception.Message.Contains("-1"));
        }

        [TestMethod]
        public void Add_Should_Ignore_Number_Greater_Than_1000()
        {
            var result = StringCalculator.Add("1,1000");

            Assert.AreEqual(1, result);
        }
    }
}