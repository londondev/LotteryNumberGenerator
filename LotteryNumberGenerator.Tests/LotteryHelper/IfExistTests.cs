using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LotteryNumberGenerator.Service;
using System.Collections.Generic;

namespace LotteryNumberGenerator.Tests.Helper
{
    [TestClass]
    public class IfExistTests
    {
        int[] sampleLotteryNumber = new int[6] { 1, 2, 3, 4, 5, 6 };

        [TestMethod]
        public void Should_Return_False_If_There_Is_No_Number_In_The_Number_Pool()
        {
            var result=LotteryHelper.IfExist(sampleLotteryNumber, new List<int[]>());

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Should_Return_True_If_Number_Exist_In_Pool_In_Same_Order()
        {
            var list = new List<int[]>();
            list.Add(sampleLotteryNumber);
            var result = LotteryHelper.IfExist(sampleLotteryNumber, list);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Should_Return_True_If_Number_Exist_In_Pool_In_Different_Order()
        {
            var list = new List<int[]>();
            list.Add(new int[6] { 4, 1, 2, 3, 6, 5 });
            var result = LotteryHelper.IfExist(sampleLotteryNumber, list);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Should_Return_False_If_Number_Does_Not_Exist_In_Pool()
        {
            var list = new List<int[]>();
            list.Add(new int[6] { 4, 1, 2, 3, 6, 7 });
            var result = LotteryHelper.IfExist(sampleLotteryNumber, list);

            Assert.AreEqual(false, result);
        }


    }
}
