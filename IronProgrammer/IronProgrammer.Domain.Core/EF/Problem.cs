using System.Collections.Generic;
using IronProgrammer.Models.EF;

namespace IronProgrammer.Domain.Core.EF
{
    public class Problem
    {
        public int Id { get; set; }
        public int? TypeProblemId { get; set; }
        public virtual TypeProblem TypeProblem { get; set; }


        public int? ComplexityId { get; set; }
        public virtual Complexity Complexity { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }

        public virtual ICollection<ProblemAttribute> TaskAttributes { get; set; }


        public Problem()
        {
            Topics = new List<Topic>();
            TaskAttributes = new List<ProblemAttribute>();
        }
    }
}