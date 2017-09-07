using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronProgrammer.Models.GenericTests
{
    public class CharacterGenerator : IRandomGenerator<Char>
    {
        public char Generate(char from, char to)
        {
            Random random = new Random();
            return Convert.ToChar(random.Next(from, to + 1));
        }
    }
}
