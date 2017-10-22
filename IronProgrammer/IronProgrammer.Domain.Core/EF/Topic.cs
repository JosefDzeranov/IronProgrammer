using System.Collections.Generic;

namespace IronProgrammer.Domain.Core.EF
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Problem> OriginalTasks { get; set; }
        public Topic()
        {
            OriginalTasks = new List<Problem>();
        }
    }
}