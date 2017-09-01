using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IronProgrammer.Models.EF
{

    enum EnumTypeProblems
    {
        OneAnswer,
        MoreAnswer
    }
    public class Problem
    {
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
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