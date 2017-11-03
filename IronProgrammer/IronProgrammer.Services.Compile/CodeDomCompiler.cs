using System;
using System.CodeDom.Compiler;
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
        /// <param name="code">The code.</param>
        /// <param name="exeName">Name executable file.</param>
        /// <param name="assemblyLocations">The assembly locations.</param>
        /// <returns>
        /// The assembly.
        /// </returns>
        public Assembly Compile(string code, string exeName, params string[] assemblyLocations)
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

            var result = _compiler.CompileAssemblyFromSource(parameters, code);

            if (result.Errors.Count > 0)
            {
                throw new CodeDomCompilerException("Assembly could not be created.", result);
            }

            try
            {
                return result.CompiledAssembly;
            }
            catch (Exception ex)
            {
                throw new CodeDomCompilerException("Assembly could not be created.", result, ex);
            }
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
