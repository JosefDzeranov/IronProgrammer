using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IronProgrammer.Models.EF
{
    public class Institution
    {
        public int InstitutionID { get; set; }
        public string Name { get; set; }

        [ForeignKey("City")]
        public int CityID { get; set; }
        public virtual City City { get; set; }

        public virtual ICollection<UserProfile> UsersCanModify { get; set; }
    }
}