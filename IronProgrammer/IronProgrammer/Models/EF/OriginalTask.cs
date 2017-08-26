using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronProgrammer.Models.EF
{
    public class OriginalTask
    {
        public int Id { get; set; }

        public virtual ICollection<CodeLine> Codelines { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }

        public virtual ICollection<TaskAttribute> TaskAttributes { get; set; }

        public virtual ProgrammingLanguage Language { get; set; }
        public OriginalTask()
        {
            Topics = new List<Topic>();
            TaskAttributes = new List<TaskAttribute>();
            Codelines = new List<CodeLine>();
        }
    }
}