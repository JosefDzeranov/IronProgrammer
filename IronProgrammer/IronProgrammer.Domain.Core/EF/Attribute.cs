using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronProgrammer.Models.EF
{
    public class Attribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TaskAttribute> TaskAttributes { get; set; }
        public Attribute()
        {
            TaskAttributes = new List<TaskAttribute>();
        }
    }
}