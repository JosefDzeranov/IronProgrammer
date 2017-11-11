using System.Collections.Generic;
using IronProgrammer.Common;
using Microsoft.CodeAnalysis.Emit;

namespace IronProgrammer.Services.Compile.Helpers
{
    internal static class MappingHelper
    {
        internal static CompileResult ToCompileResult(this EmitResult emitResult)
        {
            var compileResult = new CompileResult { Success = emitResult.Success, Errors = new List<Error>() };
            foreach (var diagnostic in emitResult.Diagnostics)
            {
                compileResult.Errors.Add(new Error { Message = diagnostic.GetMessage() });
            }
            return compileResult;
        }
    }
}
