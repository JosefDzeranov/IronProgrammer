using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronProgrammer.Models.EF
{
    public class TypeTask
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<OriginalTask> OriginalTasks { get; set; }
        public TypeTask()
        {
            OriginalTasks = new List<OriginalTask>();
        }
    }
}