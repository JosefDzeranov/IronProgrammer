using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronProgrammer.GenericTests
{
    public class RandomCreatingTestInt : IRandomCreatingTest<Int32>
    {
        public Int32 CreateTest(Int32 begin, Int32 end, Func<Int32, bool> condition)
        {
            Random random = new Random();
            Int32 result = random.Next(begin, end);
            while (!condition(result))
            {
                result = random.Next(begin, end);
            }
            return result;
        }
    }
}