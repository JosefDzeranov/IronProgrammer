using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronProgrammer.Models.EF
{
    public class TaskAttribute
    {
        public int Id { get; set; }
        public virtual OriginalTask Task { get; set; }
        public virtual Attribute Attribute { get; set; }
        public string Value { get; set; }
    }

}