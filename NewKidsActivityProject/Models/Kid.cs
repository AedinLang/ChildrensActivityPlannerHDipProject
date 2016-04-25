using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewKidsActivityProject.Models
{
    /*//enums for the Child Table Model
    public enum Medical { yes, no };
    public enum FirstAid { yes, no };*/

    public class Kid
    {
        //Auto properties - constraints to be applied
        public int KidID { get; set; }

        [Required(ErrorMessage = "Enter child's first name")]
        [StringLength(20)]
        [Display (Name ="Child")]
        public string FirstName { get; set; }

        [Required (ErrorMessage = "Enter child's second name")]
        [StringLength(20)]
        [Display (Name =" ")]       //To get desired format for kidDetails view
        public string LastName { get; set; }

        //Property to combine FirstName,LasName and DOB to identify unique child for Create Enrollment in EnrollmentController 
        public string Fullname
        {
            get
            {
                return string.Format("{0} {1}, {2}", FirstName, LastName, DOB.ToString("d"));
            }
        }

        [Required(ErrorMessage = "Enter a valid address")]
        [StringLength(50)]
        [Display(Name ="Address")]
        public string Address { get; set; }

        [Required(ErrorMessage ="DOB must be dd/mm/yyyy format")]
        [DataType(DataType.Date)]   //gives drop down calender
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name ="Date of birth")]
        public DateTime DOB { get; set; }

        [Required]
        [Display (Name="Medical issues?")]
        public bool MedicalIssues { get; set; }

        [Required]
        [Display(Name ="Medical intervention?")]
        public bool MedicalIntervention { get; set; }

        [Required(ErrorMessage = "Enter guardian's first name")]
        [StringLength(20)]
        [Display(Name = "Guardian")]
        public string GuardianFirstName { get; set; }

        [Required(ErrorMessage = "Enter guardian's second name")]
        [StringLength(20)]
        [Display(Name =" ")]
        public string GuardianLastName { get; set; }
 
        [Required(ErrorMessage ="Enter a valid phone number")]
        [StringLength(15)]
        [Display (Name ="Contact number")]
        public string GuardianContactNumber { get; set; }

        [EmailAddress]
        [Display(Name ="E-mail")]
        public string ContactEmail { get; set; }

        //Navigation properties
        //One child can have many enrollments - use ICollection
        public virtual ICollection<Enrollment> Enrollments { get; set; }


    }
}