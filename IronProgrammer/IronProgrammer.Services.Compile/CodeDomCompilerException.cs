using System;
using System.CodeDom.Compiler;

namespace IronProgrammer.Services.Compile
{
    public class CodeDomCompilerException : Exception
    {
        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public CompilerResults Result { get; private set; }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="!:RoslynCompilationException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="result">The result.</param>
        /// <param name="innerException">The inner exception.</param>
        public CodeDomCompilerException(string message, CompilerResults result, Exception innerException = null) : base(message, innerException)
        {
            this.Result = result;
        }
    }
}
