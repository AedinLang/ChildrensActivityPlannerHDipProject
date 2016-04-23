using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewKidsActivityProject.Models
{
    //enum for day of week
    public enum Day { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };

    //enum for type of activity so get dropdown list???? Is there another way of getting a drop down so can add new activities????
    public class Activity
    {
        //auto properties

        //Primary key
        public int ActivityID { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        [Display(Name ="Activity")]
        public string NameOfActivity { get; set; }

        [Required]
        [Display(Name ="Day of week")]
        public Day DayOfActivity { get; set; }

        [Required]
        [Display (Name="Time")]
        [DisplayFormat(DataFormatString = "{0:H:mm}")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime TimeOfActivity { get; set; }

        [Required]
        [Display (Name ="Price for one term")]
        public decimal ActivityPrice { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Instructor")]
        public string InstructorFirstName { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name =" ")]
        public string InstructorLastName { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name ="Contact Number")]
        public string InstructorContactNumber { get; set; }

        [EmailAddress]
        [StringLength(25)]
        [Display(Name ="E-mail")]
        public string InstructorEmail { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name="Description")]
        public string Description { get; set; }


        //navigation properties
        //one activity can have many enrollments - use ICollection
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}