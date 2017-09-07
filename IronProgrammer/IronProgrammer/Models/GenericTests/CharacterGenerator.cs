using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronProgrammer.Models.GenericTests
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
