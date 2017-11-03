using System.Reflection;

namespace IronProgrammer.Services.Interfaces
{
    public interface ICompiler
    {
        /// Compiles the specified code the sepcified assembly locations.
        Assembly Compile(string code, params string[] assemblyLocations);
    }
}
