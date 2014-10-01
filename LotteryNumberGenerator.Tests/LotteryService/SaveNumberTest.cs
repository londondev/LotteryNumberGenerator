using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LotteryNumberGenerator.Service;
using Rhino.Mocks;
using System.Linq;


namespace LotteryNumberGenerator.Tests.LotteryService
{
    [TestClass]
    public class SaveNumberTest
    {
        IRandomNumberGeneratorService _randomNumberGeneratorService;
        ILotteryNumberRepository _lotteryNumberRepository;
        ILotteryService _lotteryService;
        [TestInitialize]
        public void TestSetup()
        {
            _randomNumberGeneratorService = MockRepository.GenerateMock<IRandomNumberGeneratorService>();
            _randomNumberGeneratorService.Stub(s => s.GenerateNumbers(Arg<int>.Is.Anything, Arg<int>.Is.Anything, Arg<int>.Is.Anything)).Return(
                _sampleLotteryNumber);
            _lotteryNumberRepository = MockRepository.GenerateStub<ILotteryNumberRepository>();

            _lotteryService = new LotteryNumberGenerator.Service.LotteryService(_randomNumberGeneratorService, _lotteryNumberRepository);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Throw_Argument_Exception_If_The_Number_Is_Already_Added_To_Draw()
        {
            _lotteryNumberRepository.Stub(service => service.SaveLotteryNumber(Arg<int[]>.Is.Anything)).Throw(new ArgumentException());
             _lotteryService.SaveNumber(SampleLotteryNumber);
        }

        private int[] _sampleLotteryNumber = new int[6] { 44, 33, 22, 11, 5, 4 };
        private int[] SampleLotteryNumber
        {
            get { return _sampleLotteryNumber; }
            set { _sampleLotteryNumber = value; }
        }
    }
}
