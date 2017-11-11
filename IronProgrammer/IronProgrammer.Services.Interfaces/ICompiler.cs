using IronProgrammer.Common;
using System.Collections.Generic;

namespace IronProgrammer.Services.Interfaces
{
    public interface ICompiler
    {
        /// Compiles the specified code the sepcified assembly locations.
        CompileResult Compile(string source, string exeName, List<string> assemblyLocations);
    }
}
