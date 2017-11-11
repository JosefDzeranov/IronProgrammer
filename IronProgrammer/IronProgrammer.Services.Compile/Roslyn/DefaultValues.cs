using System.Collections.Generic;

namespace IronProgrammer.Services.Compile.Roslyn
{
    internal sealed class DefaultValues
    {
        internal const string CompilePath = @"D:\Compilers\";
        internal static readonly IEnumerable<string> SystemNamespaces =
            new[]
            {
                "System",
                "System.IO",
                "System.Net",
                "System.Linq",
                "System.Text",
                "System.Text.RegularExpressions",
                "System.Collections.Generic"
            };

        internal static readonly List<string> DefaultAssemblies = new List<string>()
        {
            "mscorlib",
            "System",
            "System.Core"
        };

        internal static readonly string RuntimePath =
            @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6\{0}.dll";

    }
}
