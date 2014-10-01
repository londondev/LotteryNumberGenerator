using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LotteryNumberGenerator.Service
{
    public class LotteryService : ILotteryService
    {
        IRandomNumberGeneratorService _randomNumberGeneratorService;
        ILotteryNumberRepository _lotteryNumberRepository;

        public LotteryService(IRandomNumberGeneratorService randomNumberGeneratorService,
                              ILotteryNumberRepository lotteryNumberRepository)
        {
            _randomNumberGeneratorService = randomNumberGeneratorService;
            _lotteryNumberRepository = lotteryNumberRepository;
        }

        public int[] GenerateLotteryNumbers()
        {
            return _randomNumberGeneratorService.GenerateNumbers(6, 1, 50);
        }

        public void SaveNumber(int[] number)
        {
            _lotteryNumberRepository.SaveLotteryNumber(number);
        }
    }
}