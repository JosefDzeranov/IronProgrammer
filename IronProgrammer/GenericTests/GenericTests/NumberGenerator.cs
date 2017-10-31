using System;
using IronProgrammer.Services.Interfaces;

namespace GenericTests.GenericTests
{
    public class NumberGenerator : IRandomGenerator<Int32>
    {
        public Int32 From { get; set; }
        public Int32 To { get; set; }
        public NumberGenerator(Int32 from, Int32 to)
        {
            From = from;
            To = to;
        }
        public Int32 Generate()
        {
            Random random = new Random();

            return random.Next(From, To + 1);

        }
    }


}