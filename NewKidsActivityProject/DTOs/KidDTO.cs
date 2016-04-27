using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewKidsActivityProject.DTOs
{
    public class KidDTO
    {
        public string FirstName { get; set; }
        public string LastName { get;set;}
        public DateTime DOB { get; set; }
        public string Enrolment { get; set; }
    }
}