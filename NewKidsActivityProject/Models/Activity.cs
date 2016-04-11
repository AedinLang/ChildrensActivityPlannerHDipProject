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
        public string NameOfActivity { get; set; }

        [Required]
        public Day DayOfActivity { get; set; }

        [Required]
        public DateTime TimeOfActivity { get; set; }

        [Required]
        public decimal ActivityPrice { get; set; }

        [Required]
        [StringLength(15)]
        public string InstructorFirstName { get; set; }

        [Required]
        [StringLength(15)]
        public string InstructorLastName { get; set; }

        [Required]
        [StringLength(15)]
        public string InstructorContactNumber { get; set; }

        [EmailAddress]
        [StringLength(25)]
        public string InstructorEmail { get; set; }


        //navigation properties
        //one activity can have many enrollments - use ICollection
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}