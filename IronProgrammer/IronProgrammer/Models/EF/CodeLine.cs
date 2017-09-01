using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronProgrammer.Models.EF
{
    public class CodeLine
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public virtual Problem Task { get; set; }
    }
}