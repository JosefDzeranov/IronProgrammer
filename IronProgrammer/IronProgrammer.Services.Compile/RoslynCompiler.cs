using System.IO;
using System.Linq;
using System.Reflection;
using IronProgrammer.Services.Interfaces;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace IronProgrammer.Services.Compile
{
    /// <summary>
    /// Compiler that uses the Roslyn compiler (<see cref="CSharpCompilation" />).
    /// </summary>
    public class RoslynCompiler : ICompiler
    {
        private const string path = @"D:\\Compilers";


        /// <summary>
        /// Gets the compilation options.
        /// </summary>
        /// <value>
        /// The options.
        /// </value>
        public CSharpCompilationOptions Options { get; } = new CSharpCompilationOptions(
            OutputKind.ConsoleApplication,
            reportSuppressedDiagnostics: true,
            optimizationLevel: OptimizationLevel.Release,
            generalDiagnosticOption: ReportDiagnostic.Error
        );

        /// <summary>
        /// Compiles the specified code the sepcified assembly locations.
        /// </summary>
        /// <param name="code">The code.</param>
        /// </returns>
        /// <param name="assemblyLocations">The assembly locations.</param>
        /// <returns>
        /// The assembly.
        /// <exception cref="RoslynCompilationException">Assembly could not be created.</exception>
        public Assembly Compile(string code, string exeName, params string[] assemblyLocations)
        {
            string netAssembliesDirectory = Path.GetDirectoryName(typeof(object).Assembly.Location);
            var references = assemblyLocations.Select(l => MetadataReference.CreateFromFile(netAssembliesDirectory + "\\" + l));

            var compilation = CSharpCompilation.Create(
                exeName,
                references: references,
                syntaxTrees: new SyntaxTree[] { CSharpSyntaxTree.ParseText(code) },
                options: this.Options
            );

            using (var ms = new MemoryStream())
            {
                var compilationResult = compilation.Emit(ms);

                if (compilationResult.Success)
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    return Assembly.Load(ms.ToArray());
                }

                throw new RoslynCompilationException("Assembly could not be created.", compilationResult);
            }
        }
    }
}
