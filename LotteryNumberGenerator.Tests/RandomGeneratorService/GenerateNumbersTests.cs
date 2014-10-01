using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LotteryNumberGenerator.Service;

namespace LotteryNumberGenerator.Tests.RandomGeneratorService
{

   
    /// <summary>
    /// Summary description for GenerateNumbersTests
    /// </summary>
    [TestClass]
    public class GenerateNumbersTests
    {
        IRandomNumberGeneratorService _randomNumberGeneratorService;
        [TestInitialize]
        public void Setup()
        {
            _randomNumberGeneratorService = new RandomNumberGeneratorService();
        }
        [TestMethod]
        public void Returns_Expected_Number_Of_Numbers()
        {
            var numbers = _randomNumberGeneratorService.GenerateNumbers(5, 1, 50);

            Assert.AreEqual(5, numbers.Length);
        }
        [TestMethod]
        public void Return_Numbers_Within_Given_Range()
        {
            var numbers = _randomNumberGeneratorService.GenerateNumbers(5, 35, 40);

            //All numbers are in the range
            Assert.IsTrue(numbers.Where(n=>n < 40 && n>34).Count()==5);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Throws_Out_Of_Range_Exception_When_Expected_Numbers_Less_Than_Zero()
        {
            var numbers = _randomNumberGeneratorService.GenerateNumbers(-1, 35, 40);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Throw_Argument_Exception_If_MinValue_Is_Equal_Or_Grater_Than_MaxValue()
        {
            var numbers = _randomNumberGeneratorService.GenerateNumbers(1, 35, 35);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Throws_Out_Of_Range_Exception_When_Expected_Numbers_Is_Zero()
        {
            var numbers = _randomNumberGeneratorService.GenerateNumbers(-1, 35, 40);
        }

        [TestMethod]
        public void Do_Not_Return_Duplicated_Numbers()
        {
            //Running 5 times to increase chance of catching issue. Because
            // since numbers are generated randomly, it is not possible to ensure that 
            // the method do not duplicates numbers.
            for (int i = 1; i < 5; i++)
            {
                var numbers = _randomNumberGeneratorService.GenerateNumbers(5, 35, 40);

                Assert.IsTrue(numbers.Where(n => n == 35).Count() == 1);
                Assert.IsTrue(numbers.Where(n => n == 36).Count() == 1);
                Assert.IsTrue(numbers.Where(n => n == 37).Count() == 1);
                Assert.IsTrue(numbers.Where(n => n == 38).Count() == 1);
                Assert.IsTrue(numbers.Where(n => n == 39).Count() == 1);
            }

        }
    }
}
