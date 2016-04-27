using System.ComponentModel.DataAnnotations;

namespace NewKidsActivityProject.Models
{
    public class Enrollment
    {
        //auto properties

        //Primary key
        public int EnrollmentID { get; set; }

        //Foreign key linking to Kid entity
        [Required]
        public int KidID { get; set; }

        //Foreign key linking to Activity entity
        [Required]
        public int ActivityID { get; set; }

        [Required]
        [Display (Name = "Payment Made")]
        public bool PaymentDue { get; set; }


        //Navigation properties
        //An enrollment has 1 child and 1 activity
        public virtual Activity Activity { get; set; }
        public virtual Kid Kid { get; set; }
    }
}