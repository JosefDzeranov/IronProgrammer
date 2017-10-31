using IronProgrammer.Services.Interfaces;

namespace GenericTests.GenericTests
{
    public class OneObjectGenerate<T> :ICreateTester
    {

        private IRandomGenerator<T> _generator;
        public OneObjectGenerate(IRandomGenerator<T> generator)
        {
            _generator = generator;
        }

        public string GetTest()
        {
            return _generator.Generate().ToString();
        }
    }
}