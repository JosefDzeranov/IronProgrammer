using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IronProgrammer.Models.EF
{
    public class Topic
    {
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Problem> OriginalTasks { get; set; }
        public Topic()
        {
            OriginalTasks = new List<Problem>();
        }
    }
}