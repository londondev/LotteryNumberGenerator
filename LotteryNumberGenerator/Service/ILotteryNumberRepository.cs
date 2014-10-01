using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotteryNumberGenerator.Service
{
    public interface ILotteryNumberRepository
    {
        int SaveLotteryNumber(int[] lotteryNumber);
    }
}
