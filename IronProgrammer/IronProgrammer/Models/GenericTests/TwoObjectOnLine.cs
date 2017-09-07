using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronProgrammer.Models.GenericTests
{
    public class TwoObjectOnLine<T>
    {
        private IRandomGenerator<T> _generator;
        public TwoObjectOnLine(IRandomGenerator<T> generator)
        {
            _generator = generator;
        }
        public string GetTest()
        {
            return _generator.Generate() + " " +
                _generator.Generate().ToString();
        }
    }
}