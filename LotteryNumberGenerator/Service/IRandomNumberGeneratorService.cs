using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LotteryNumberGenerator.Service
{
    public interface IRandomNumberGeneratorService
    {
        int[] GenerateNumbers(int numberOfNumbers, int min, int max);
    }
}