using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using IronProgrammer.Services.Interfaces;
using Microsoft.CSharp;


namespace IronProgrammer.Services.Compile
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
        private const string Path = "D:\\Compilers\\";

        /// <summary>
        /// Compiles the specified code the sepcified assembly locations.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="exeName">Name executable file.</param>
        /// <param name="assemblyLocations">The assembly locations.</param>
        /// <returns>
        /// The assembly.
        /// </returns>
        public bool Compile(string source, string exeName, List<string> assemblyLocations)
        {
            var parameters = new CompilerParameters
            {
                GenerateExecutable = true,
                GenerateInMemory = true
            };

            parameters.OutputAssembly = Path + exeName;
            foreach (string assemblyLocation in assemblyLocations)
            {
                parameters.ReferencedAssemblies.Add(assemblyLocation);
            }

            var result = _compiler.CompileAssemblyFromSource(parameters, source);

            if (result.Errors.Count > 0)
            {
                throw new CodeDomCompilerException("Assembly could not be created.", result);
            }
            return true;
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
