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
        public string GetTest(T fromObect1, T toObject1, T fromObect2, T toObject2)
        {
            return _generator.Generate(fromObect1, toObject1).ToString() + " " +
                _generator.Generate(fromObect2, toObject2).ToString();
        }
    }
}