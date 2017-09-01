using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronProgrammer.Models.EF
{
    public class TypeProblem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Problem> OriginalTasks { get; set; }
        public TypeProblem()
        {
            OriginalTasks = new List<Problem>();
        }
    }
}