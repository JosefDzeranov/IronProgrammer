using System;
using System.Text;
using IronProgrammer.Services.Interfaces;

namespace GenericTests.GenericTests
{
    public class OneNumberInLineAndMoreObjectsInSecondLine<TSecondLine>:ICreateTester
    {
        private IRandomGenerator<Int32> _firstLineGenerator;
        private IRandomGenerator<TSecondLine> _secondLineGenerator;
        public OneNumberInLineAndMoreObjectsInSecondLine(IRandomGenerator<Int32> firstGenerator,
                                                            IRandomGenerator<TSecondLine> secondGenerator)
        {
            _firstLineGenerator = firstGenerator;
            _secondLineGenerator = secondGenerator;
        }
        public string GetTest()
        {
            Int32 number = _firstLineGenerator.Generate();
            string result = number.ToString();
            StringBuilder temp = new StringBuilder(2 * number);
            for (int i = 0; i < number; i++)
            {
                temp.Append(_secondLineGenerator.Generate().ToString());
                temp.Append(" ");
            }
            return result + "\n" + temp.ToString();
        }
    }
}