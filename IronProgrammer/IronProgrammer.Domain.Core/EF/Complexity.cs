using System.Collections.Generic;
using IronProgrammer.Models.EF;

namespace IronProgrammer.Domain.Core.EF
{
    public class Complexity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Problem> OriginalTasks { get; set; }

        public Complexity()
        {
            OriginalTasks = new List<Problem>();
        }
    }
}