using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronProgrammer.GenericTests
{
    public interface IRandomCreatingTest<T>
    {
        T CreateTest(T begin, T end, Func<T, bool> condition);
    }
}