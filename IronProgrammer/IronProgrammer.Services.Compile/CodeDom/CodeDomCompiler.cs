using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using IronProgrammer.Common;
using IronProgrammer.Services.Compile.Roslyn;
using IronProgrammer.Services.Interfaces;
using Microsoft.CSharp;

namespace IronProgrammer.Services.Compile.CodeDom
{
    /// <inheritdoc cref="" />
    /// <summary>
    /// Compiler that uses the <see cref="T:Microsoft.CSharp.CSharpCodeProvider" /> for compilation.
    /// </summary>
    /// <seealso cref="!:KeesTalksTech.Utilities.Compilation.ICompiler" />
    /// <seealso cref="T:System.IDisposable" />
    public class CodeDomCompiler : ICompiler, IDisposable
    {
        private readonly CSharpCodeProvider _compiler = new CSharpCodeProvider();

        /// <summary>
        /// Compiles the specified code the sepcified assembly locations.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="exeName">Name executable file.</param>
        /// <param name="assemblyLocations">The assembly locations.</param>
        /// <returns>
        /// The assembly.
        /// </returns>
        public CompileResult Compile(string source, string exeName, List<string> assemblyLocations)
        {
            var parameters = new CompilerParameters
            {
                GenerateExecutable = true,
                GenerateInMemory = true
            };

            parameters.OutputAssembly = DefaultValues.CompilePath + exeName;
            foreach (string assemblyLocation in assemblyLocations)
            {
                parameters.ReferencedAssemblies.Add(assemblyLocation);
            }

            var result = _compiler.CompileAssemblyFromSource(parameters, source);

            if (result.Errors.Count > 0)
            {
                return new CompileResult() { Success = false };
            }
            return new CompileResult() { Success = true };
        }

        /// <inheritdoc />
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _compiler?.Dispose();
        }
    }
}
