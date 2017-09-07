using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronProgrammer.Models.GenericTests
{
    // 
    interface IGeneratable<T>
    {
        T Generate(T start, T end);
    }
}
