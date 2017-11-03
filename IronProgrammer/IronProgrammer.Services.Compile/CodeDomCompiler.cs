using System;
using System.CodeDom.Compiler;
using System.Reflection;
using IronProgrammer.Services.Interfaces;
using Microsoft.CSharp;


namespace IronProgrammer.Services.Compile
{
    public class CodeDomCompiler : ICompiler, IDisposable
    {
        private readonly CSharpCodeProvider _compiler = new CSharpCodeProvider();
        
        /// <summary>
        /// Compiles the specified code the sepcified assembly locations.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="assemblyLocations">The assembly locations.</param>
        /// <returns>
        /// The assembly.
        /// </returns>
        public Assembly Compile(string code, params string[] assemblyLocations)
        {
            var parameters = new CompilerParameters
            {
                GenerateExecutable = false,
                GenerateInMemory = true
            };

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
