using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IronProgrammer.Models.EF
{

    public enum Attributes
    {
        Description,
        Input,
        Output
    }
    public class ProblemAttribute
    {
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual Problem Task { get; set; }
        public Attributes Attribute { get; set; }
        public string Value { get; set; }
    }

}