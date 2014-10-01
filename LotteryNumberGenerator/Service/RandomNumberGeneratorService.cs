using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LotteryNumberGenerator.Service
{
    public class RandomNumberGeneratorService : IRandomNumberGeneratorService
    {
        private static readonly Random Rnd = new Random();

        public int[] GenerateNumbers(int numberOfNumbers, int min, int max)
        {
            if (numberOfNumbers < 1)
                throw new IndexOutOfRangeException("Array length should not be less than 1");
            if (!(min < max))
                throw new ArgumentException("Minimum value of the range must smaller than the max value");
            var numbers=new int[numberOfNumbers];
            for (int i = 0; i < numberOfNumbers; i++)
                numbers[i] = GetRandomNumberNotInArray(numbers,min,max);

            return numbers;
        }

        private static int GetRandomNumberNotInArray(int[] arr, int min, int max)
        {
            var next = Rnd.Next(min, max);
            return !arr.Contains(next) ? next : GetRandomNumberNotInArray(arr,min,max);
        } 
    }
}