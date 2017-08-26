using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IronProgrammer.Models.EF
{
    public class City
    {
        public int CityId { get; set; }

        [ForeignKey("Country")]
        public int CountryID { get; set; }
        public virtual Country Country { get; set; }

        public string Region { get; set; }
        public string Area { get; set; }
        public string Name { get; set; }

    }
}