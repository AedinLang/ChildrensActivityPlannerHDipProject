using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewKidsActivityProject.Models
{
    //enums for the Child Table Model
    public enum Medical { yes, no };
    public enum FirstAid { yes, no };

    public class Kid
    {
        //Auto properties - constraints to be applied
        public int KidID { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public Medical MedicalIssues { get; set; }

        [Required]
        public FirstAid MedicalIntervention { get; set; }

        [Required]
        [StringLength(20)]
        public string GuardianFirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string GuardianLastName { get; set; }

        [Required]
        [StringLength(15)]
        public string GuardianContactNumber { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        //Navigation properties
        //One child can have many enrollments - use ICollection
        public virtual ICollection<Enrollment> Enrollments { get; set; }


    }
}