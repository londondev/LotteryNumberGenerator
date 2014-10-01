using LotteryNumberGenerator.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LotteryNumberGenerator.Controllers
{
    public class LotteryController : ApiController
    {
        IRandomNumberGeneratorService _randomNumberGeneratorService;
        ILotteryNumberRepository _lotteryNumberRepository;

        public LotteryController(IRandomNumberGeneratorService randomNumberGeneratorService,
                              ILotteryNumberRepository lotteryNumberRepository)
        {
            _randomNumberGeneratorService = randomNumberGeneratorService;
            _lotteryNumberRepository = lotteryNumberRepository;
        }

        [HttpGet]
        [Route("numbers")]
        public int[] GetNumbers(){
            return _randomNumberGeneratorService.GenerateNumbers(6,1,50);
        }

        [HttpPost]
        [Route("saveNumber")]
        public int SaveNumber(int[] number)
        {
            return _lotteryNumberRepository.SaveLotteryNumber(number);
        }
    }
}
