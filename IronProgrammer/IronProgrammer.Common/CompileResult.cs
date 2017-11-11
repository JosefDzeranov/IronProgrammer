using System.Collections.Generic;

namespace IronProgrammer.Common
{
    public class CompileResult
    {
        public bool Success { get; set; }

        public List<Error> Errors { get; set; }

        public string PathToAssembly { get; set; }
    }
}
