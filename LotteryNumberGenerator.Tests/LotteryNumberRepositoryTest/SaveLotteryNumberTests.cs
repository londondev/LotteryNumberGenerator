using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LotteryNumberGenerator.Service;

namespace LotteryNumberGenerator.Tests.LotteryNumberRepositoryTest
{
    [TestClass]
    public class SaveLotteryNumberTests
    {
        int[] sampleLotteryNumber = new int[6] { 1, 2, 3, 4, 5, 6 };
        ILotteryNumberRepository _lotteryNumberRepository; 

        [TestInitialize]
        public void TestSetup()
        {
            _lotteryNumberRepository = new LotteryNumberRepository();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_Save_And_Return_Expected_Count_Of_Lottery_Number()
        {
           var result1= _lotteryNumberRepository.SaveLotteryNumber(sampleLotteryNumber);
            sampleLotteryNumber[0] = 49;
           var result2= _lotteryNumberRepository.SaveLotteryNumber(sampleLotteryNumber);

           Assert.AreEqual(result1, 1);
           Assert.AreEqual(result2, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_Throw_Exception_If_Save_Same_Number()
        {
           _lotteryNumberRepository.SaveLotteryNumber(sampleLotteryNumber);

           _lotteryNumberRepository.SaveLotteryNumber(sampleLotteryNumber);
        }
    }
}
