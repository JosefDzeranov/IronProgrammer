using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IronProgrammer.Common;
using IronProgrammer.Services.Compile.Helpers;
using IronProgrammer.Services.Interfaces;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis.Text;

namespace IronProgrammer.Services.Compile.Roslyn
{
    /// <summary>
    /// Compiler that uses the Roslyn compiler (<see cref="CSharpCompilation" />).
    /// </summary>
    public class RoslynCompiler : ICompiler
    {
        /// <summary>
        /// Gets the compilation options.
        /// </summary>
        private static readonly CSharpCompilationOptions Options = new CSharpCompilationOptions(
                 OutputKind.ConsoleApplication)
             .WithOverflowChecks(true)
             .WithOptimizationLevel(OptimizationLevel.Release)
             .WithUsings(DefaultValues.SystemNamespaces);

        /// <inheritdoc />
        /// <summary>
        /// Compiles the specified code the sepcified assembly locations.
        /// </summary>
        /// <param name="source">The code.</param>
        /// <param name="exeName">Assemply name</param>
        ///  <param name="assemblyLocations">The assembly locations.</param>
        /// <returns />
        /// The assembly.
        /// <exception cref="T:IronProgrammer.Services.Compile.Roslyn.RoslynCompilationException">Assembly could not be created.</exception>
        public CompileResult Compile(string source, string exeName, List<string> assemblyLocations)
        {
            assemblyLocations.AddRange(DefaultValues.DefaultAssemblies);
            var references = assemblyLocations.Select(l => MetadataReference.CreateFromFile(string.Format(DefaultValues.RuntimePath, l)));

            var parsedSyntaxTree = Parse(source, "", CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp6));

            var compilation = CSharpCompilation.Create(exeName, new SyntaxTree[] { parsedSyntaxTree }, references, Options);
            try
            {
                return compilation.Emit(DefaultValues.CompilePath + exeName).ToCompileResult();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static SyntaxTree Parse(string text, string filename = "", CSharpParseOptions options = null)
        {
            var stringText = SourceText.From(text, Encoding.UTF8);
            return SyntaxFactory.ParseSyntaxTree(stringText, options, filename);
        }
    }
}
