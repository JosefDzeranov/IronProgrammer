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

        public string Email { get; set; }

        public string FistName { get; set; }
        public string SecondName { get; set; }
    }
}