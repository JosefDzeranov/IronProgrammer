using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using IronProgrammer.Services.Interfaces;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis.Text;

namespace IronProgrammer.Services.Compile
{
    /// <summary>
    /// Compiler that uses the Roslyn compiler (<see cref="CSharpCompilation" />).
    /// </summary>
    public class RoslynCompiler : ICompiler
    {

        private readonly string _path = @"D:\Compilers\";

        private static readonly IEnumerable<string> _defaultNamespaces =
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
        private readonly List<string> _defaultAssemblies = new List<string>()
        {
            "mscorlib",
            "System",
            "System.Core"
        };



        private readonly string _runtimePath =
            @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6\{0}.dll";

        /// <summary>
        /// Gets the compilation options.
        /// </summary>
        private static readonly CSharpCompilationOptions Options = new CSharpCompilationOptions(
                 OutputKind.ConsoleApplication)
             .WithOverflowChecks(true)
             .WithOptimizationLevel(OptimizationLevel.Release)
             .WithUsings(_defaultNamespaces);


        /// <summary>
        /// Compiles the specified code the sepcified assembly locations.
        /// </summary>
        /// <param name="source">The code.</param>
        /// <param name="exeName">Assemply name</param>
        ///  <param name="assemblyLocations">The assembly locations.</param>
        /// <returns/>
        /// The assembly.
        /// <exception cref="RoslynCompilationException">Assembly could not be created.</exception>
        public bool Compile(string source, string exeName, List<string> assemblyLocations)
        {
            assemblyLocations.AddRange(_defaultAssemblies);
            var references = assemblyLocations.Select(l => MetadataReference.CreateFromFile(string.Format(_runtimePath, l)));

            var parsedSyntaxTree = Parse(source, "", CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp6));

            var compilation = CSharpCompilation.Create(exeName, new SyntaxTree[] { parsedSyntaxTree }, references, Options);
            EmitResult result = null;
            try
            {
                result = compilation.Emit(_path + exeName);
                //if (!result.Success)
                //{
                //    List<string> ass = new List<string>();
                //    foreach (var diagnostic in result.Diagnostics)
                //    {
                //        ass.Add(diagnostic.ToString());
                //    }
                //}
                return result.Success;
            }
            catch (Exception)
            {
                throw new RoslynCompilationException("Assembly could not be created.", result);
            }
        }

        private static SyntaxTree Parse(string text, string filename = "", CSharpParseOptions options = null)
        {
            var stringText = SourceText.From(text, Encoding.UTF8);
            return SyntaxFactory.ParseSyntaxTree(stringText, options, filename);
        }
    }
}
