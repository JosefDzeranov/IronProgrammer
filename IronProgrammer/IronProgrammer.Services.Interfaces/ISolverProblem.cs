using System.Reflection.Emit;
using IronProgrammer.Domain.Core.EF;

namespace IronProgrammer.Services.Interfaces
{
    public interface ISolverProblem
    {
        void BuildTask(Problem problem);
        void PostTask(Problem problem);
    }
}
