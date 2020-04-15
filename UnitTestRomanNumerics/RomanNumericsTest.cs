using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumerics;
using System;

namespace UnitTestRomanNumerics
{
    [TestClass]
    public class RomanNumericsTest
    {
        [TestMethod]
        public void InputMMCMXCIX()
        {
            // arrange
            string res = "MMCMXCIX";
            // act           
            int actual = RomanConverter.RomanToInt(res);
            // assert
            Assert.AreEqual(2999, actual);
        }

        [TestMethod]
        public void InputEmptyInString()
        {
            //arrange
            string str = RomanConverter.input = "";
            //assert
            Assert.ThrowsException<ArgumentException>(() => RomanConverter.CheckInputString(str));
        }

        [TestMethod]
        public void InputWhiteSpaceInString()
        {
            //arrange
            string str = RomanConverter.input = "   ";
            //assert
            Assert.ThrowsException<ArgumentException>(() => RomanConverter.CheckInputString(str));
        }

        [TestMethod]
        public void InputNumberInString()
        {
            //arrange
            string str = RomanConverter.input = "1234";
            //assert
            Assert.ThrowsException<ArgumentException>(() => RomanConverter.CheckInputString(str));
        }

        [TestMethod]
        public void InputPunctuationInString()
        {
            //arrange
            string str = RomanConverter.input = ",.?";
            //assert
            Assert.ThrowsException<ArgumentException>(() => RomanConverter.CheckInputString(str));
        }

        [TestMethod]
        public void InputSymbolsValueInString()
        {
            //arrange
            string str = RomanConverter.input = "/-";
            //assert
            Assert.ThrowsException<ArgumentException>(() => RomanConverter.CheckInputString(str));
        }

        [TestMethod]
        public void InputCyrillicInString()
        {
            //arrange
            string str = RomanConverter.input = "привет";
            //assert
            Assert.ThrowsException<ArgumentException>(() => RomanConverter.CheckInputString(str));
        }

        [TestMethod]
        public void ArgumentOutOfRange()
        {
            //arrange
            string str = RomanConverter.input = "MMMM";
            //assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => RomanConverter.RomanToInt(str));
        }

        [TestMethod]
        public void StackOverflow()
        {
            //arrange
            string str = RomanConverter.input = "XXXMMMCXIT";
            //assert
            Assert.ThrowsException<StackOverflowException>(() => RomanConverter.RomanToInt(str));
        }
      
    }
}
