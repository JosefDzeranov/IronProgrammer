using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronProgrammer.Models.EF
{

    public enum Attributes
    {
        ChoiceOneAnswer
    }
    public class ProblemAttribute
    {
        public int Id { get; set; }
        public virtual Problem Task { get; set; }
        public Attributes Attribute { get; set; }
        public string Value { get; set; }
    }

}