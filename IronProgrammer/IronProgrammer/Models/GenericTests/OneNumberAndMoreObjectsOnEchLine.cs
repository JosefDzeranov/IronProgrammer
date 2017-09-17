using System;
using System.Text;

namespace IronProgrammer.Models.GenericTests
{
    public class OneNumberAndMoreObjectsOnEchLine<TObject>:ICreateTester
    {
        private IRandomGenerator<Int32> _firstLineGenerator;
        private IRandomGenerator<TObject> _linesGenerator;
        public OneNumberAndMoreObjectsOnEchLine(IRandomGenerator<Int32> firstGenerator,IRandomGenerator<TObject> secondGenerator)
        {
            _firstLineGenerator = firstGenerator;
            _linesGenerator = secondGenerator;
        }

        public string GetTest()
        {
            Int32 number = _firstLineGenerator.Generate();
            string result = number.ToString();
            StringBuilder temp = new StringBuilder(2 * number);
            for (int i = 0; i < number; i++)
            {
                temp.Append(_linesGenerator.Generate().ToString());
                temp.Append("\n");
            }
            return result + "\n" + temp.ToString();
        }
    }
}