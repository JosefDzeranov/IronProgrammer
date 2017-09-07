using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronProgrammer.Models.GenericTests
{
    public class CharacterGenerate : IGeneratable<Char>
    {
        public char Generate(char start, char end)
        {
            Random random = new Random();
            return Convert.ToChar(random.Next(start, end + 1));
        }
    }
}
}