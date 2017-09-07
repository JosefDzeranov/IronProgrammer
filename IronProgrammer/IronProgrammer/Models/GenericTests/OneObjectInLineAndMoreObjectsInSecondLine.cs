using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace IronProgrammer.Models.GenericTests
{
    public class OneObjectInLineAndMoreObjectsInSecondLine<TSecondLine>
    {
        private IRandomGenerator<Int32> _firstLineGenerator;
        private IRandomGenerator<TSecondLine> _secondLineGenerator;


        public OneObjectInLineAndMoreObjectsInSecondLine(IRandomGenerator<Int32> firstGenerator,
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