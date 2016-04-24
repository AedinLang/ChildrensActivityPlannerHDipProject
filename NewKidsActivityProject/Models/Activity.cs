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

        [Required(ErrorMessage ="An Activity Name required")]
        [StringLength(20)]
        [Display(Name ="Activity Name")]
        public string NameOfActivity { get; set; }

        [Required]
        [Display(Name ="Day of week")]
        public Day DayOfActivity { get; set; }

        /*[Required]
        [Display (Name="Time")]
        //[DisplayFormat(DataFormatString = "{0:HH:mm}")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]*/
        public DateTime? TimeOfActivity { get; set; }
        [Required(ErrorMessage = "A time ia required")]
        [Display (Name ="Time")]
        [RegularExpression(@"^(0[1-9]|1[0-2]):[0-5][0-9] (am|pm|AM|PM)$", ErrorMessage = "Invalid time")]
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
        [Display(Name = "Instructor")]
        public string InstructorFirstName { get; set; }

        [Required(ErrorMessage ="Instructor second name required")]
        [StringLength(15)]
        [Display(Name =" ")]
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
        [StringLength(150)]
        [Display(Name="Description")]
        public string Description { get; set; }


        //navigation properties
        //one activity can have many enrollments - use ICollection
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}