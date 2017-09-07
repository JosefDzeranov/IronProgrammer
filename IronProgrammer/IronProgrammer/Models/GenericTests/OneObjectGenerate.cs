using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronProgrammer.Models.GenericTests
{
    public class OneObjectGenerate<T> where T : struct
    {

        private IRandomGenerator<T> _generator;
        public OneObjectGenerate(IRandomGenerator<T> generator)
        {
            _generator = generator;
        }

        public string GetTest()
        {
            return _generator.Generate().ToString();
        }
    }
}