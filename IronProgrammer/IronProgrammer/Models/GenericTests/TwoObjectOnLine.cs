using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronProgrammer.Models.GenericTests
{
    public class TwoObjectOnLine<T,U>:ICreateTester
    {
        private IRandomGenerator<T> _generatorFirstObject;
        private IRandomGenerator<U> _generatorSecondObject;

        public TwoObjectOnLine(IRandomGenerator<T> generatorFirstObject, IRandomGenerator<U> generatorSecondObject)
        {
            _generatorFirstObject = generatorFirstObject;
            _generatorSecondObject = generatorSecondObject;
        }
        public string GetTest()
        {
            return _generatorFirstObject.Generate() + " " +
                _generatorSecondObject.Generate().ToString();
        }
    }
}