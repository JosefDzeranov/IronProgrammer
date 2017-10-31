using System;
using IronProgrammer.Services.Interfaces;

namespace GenericTests.GenericTests
{
    public class CharacterGenerator : IRandomGenerator<Char>
    {
        public Int32 From { get; set; }
        public Int32 To { get; set; }
        public CharacterGenerator(Int32 from, Int32 to)
        {
            From = from;
            To = to;
        }
        public char Generate()
        {
            Random random = new Random();
            return Convert.ToChar(random.Next(From, To + 1));
        }
    }
}
