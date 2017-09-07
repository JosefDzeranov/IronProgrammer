using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronProgrammer.Models.GenericTests
{
    public class NumberGenerate : IGeneratable<Int32>
    {
        public Int32 Generate(Int32 start, Int32 end)
        {
            Random random = new Random();
            
            return random.Next(start, end + 1);

        }
    }
}