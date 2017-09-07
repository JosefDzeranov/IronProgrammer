using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronProgrammer.Models.GenericTests
{
    // 
    public interface IRandomGenerator<T>
    {
        T Generate(T from, T to);
    }
}
