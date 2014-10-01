using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryNumberGenerator.Service
{
    public interface ILotteryService
    {
        int[] GenerateLotteryNumbers();
        void SaveNumber(int[] number);
    }
}
