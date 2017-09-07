﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronProgrammer.Models.GenericTests
{
    public class NumberGenerator : IRandomGenerator<Int32>
    {
        public Int32 Generate(Int32 from, Int32 to)
        {
            Random random = new Random();
            
            return random.Next(from, to + 1);

        }
    }
}