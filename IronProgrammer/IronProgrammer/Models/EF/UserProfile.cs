using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace IronProgrammer.Models.EF
{
    public class UserProfile
    {
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }

        [DefaultValue(null)]
        public DateTime? LastAccessTime { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }

        [DefaultValue(null)]
        public DateTime? BirthDay { get; set; }

        public string PhoneNumber { get; set; }

        public int? GradeLevel { get; set; } // Year of study

        [ForeignKey("UserCategory")]
        public int Category { get; set; }
        public virtual UserCategory UserCategory { get; set; }

        [ForeignKey("Country")]
        public int? CountryID { get; set; }
        public Country Country { get; set; }

        [ForeignKey("City")]
        public int? CityID { get; set; }
        public City City { get; set; }

        [ForeignKey("Institution")]
        public int? InstitutionID { get; set; }
        public Institution Institution { get; set; }

        [ForeignKey("CreatedByUser")]
        public int? CreatedByUserID { get; set; }
        public virtual UserProfile CreatedByUser { get; set; }

        public int? Generated { get; set; }
    }
}