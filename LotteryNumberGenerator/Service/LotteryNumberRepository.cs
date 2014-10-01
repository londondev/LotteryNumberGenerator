using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LotteryNumberGenerator.Service
{
    public class LotteryNumberRepository : ILotteryNumberRepository
    {
        private static List<int[]> LotteryNumbers = new List<int[]>();

        public int SaveLotteryNumber(int[] lotteryNumber)
        {
            if (LotteryNumbers.Count >0 && lotteryNumber.IfExist(LotteryNumbers))
                throw new ArgumentException("The number is already taken, please generate another number");
            LotteryNumbers.Add(lotteryNumber);
            return LotteryNumbers.Count;
        }
    }

    public static class LotteryHelper{
        public static bool IfExist(this int[] newItem, List<int[]> drawPool)
        {
            foreach (var numbers in drawPool)
            {
                bool isSame = true;
                foreach (var number in newItem)
                {
                    if (!numbers.Contains(number))
                    {
                        isSame = false;
                        break;
                    }
                }
                if (isSame)
                    return true;
            }
            return false;
        }
    }
}