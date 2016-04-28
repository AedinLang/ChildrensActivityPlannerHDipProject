using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewKidsActivityProject.Models
{
    //enum for day of week
    public enum Day { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };

    public class Activity
    {
        //auto properties

        //Primary key
        
        public int ActivityID { get; set; }

        [Required(ErrorMessage ="An Activity Name required")]
        [StringLength(20)]
        [Display(Name ="Activity Name")]
        public string NameOfActivity { get; set; }

        [Required(ErrorMessage = "Indicate number of places in the class")]
        [Display(Name="Places in class")]
        public int Places { get; set; }

        [Required]
        [Display(Name ="Day of week")]
        public Day DayOfActivity { get; set; }


        [DataType(DataType.Time)]
        public DateTime? TimeOfActivity { get; set; }

        [Required(ErrorMessage = "A time ia required")]
        [Display (Name ="Time")]
        [DataType(DataType.Time)]
        public string TimeOfActivityValue
        {
            get
            {
                return TimeOfActivity.HasValue ? TimeOfActivity.Value.ToString("hh:mm tt") : string.Empty;
            }

            set
            {
                TimeOfActivity = DateTime.Parse(value);
            }
        }

        [Required(ErrorMessage ="A price is required")]
        [Display (Name ="Price for one term")]
        public decimal ActivityPrice { get; set; }

        [Required(ErrorMessage ="Instructor first name required")]
        [StringLength(15)]
        [Display(Name = "Instructor First Name")]
        public string InstructorFirstName { get; set; }

        [Required(ErrorMessage ="Instructor second name required")]
        [StringLength(15)]
        [Display(Name ="Instructor Last Name")]
        public string InstructorLastName { get; set; }

        [Required(ErrorMessage ="Contact number required")]
        [StringLength(15)]
        [Display(Name ="Contact Number")]
        public string InstructorContactNumber { get; set; }

        [EmailAddress(ErrorMessage ="E-mail required")]
        [StringLength(25)]
        [Display(Name ="E-mail")]
        public string InstructorEmail { get; set; }

        [Required(ErrorMessage ="Brief description required")]
        [StringLength(100)]
        [Display(Name="Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }


        //navigation properties
        //one activity can have many enrollments - use ICollection
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}