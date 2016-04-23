using System;
using System.Collections.Generic;
using NewKidsActivityProject.Models;

namespace NewKidsActivityProject.DAL
{
    public class ActivityInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ActivityContext>
    {
        protected override void Seed(ActivityContext context)
        {
            //Populate Child table
            var children = new List<Kid>
                {
                    new Kid {FirstName="Cathal",LastName="O'Sullivan",Address="9 Prospect Manor, Rathfarnham, Dublin 16",DOB=DateTime.Parse("2004-12-15"), MedicalIssues=true, MedicalIntervention=true, GuardianFirstName="Gary", GuardianLastName="O'Sullivan",GuardianContactNumber="+353871111111",ContactEmail="garyosullivan@gmail.com" },
                    new Kid {FirstName="Cillian",LastName="O'Brien",Address="23 College Drive, Terenure, Dublin 6W",DOB=DateTime.Parse("2000-10-09"), MedicalIssues=true, MedicalIntervention=true, GuardianFirstName="Fiona", GuardianLastName="O'Brien",GuardianContactNumber="+353872222222",ContactEmail="fionaobrien@hotmail.com" },
                    new Kid {FirstName="Maeve",LastName="McDonagh",Address="12 Fosterbrook, Stillorgan, Co Dublin",DOB=DateTime.Parse("1998-06-06"), MedicalIssues=false, MedicalIntervention=true, GuardianFirstName="Mark", GuardianLastName="McDonagh",GuardianContactNumber="+353853333333",ContactEmail="markmcdonagh@gmail.com" },
                    new Kid {FirstName="Órla",LastName="O'Sullivan",Address="9 Prospect Manor, Rathfarnham, Dublin 16",DOB=DateTime.Parse("1999-04-30"), MedicalIssues=false, MedicalIntervention=false, GuardianFirstName="Aedín", GuardianLastName="Lang",GuardianContactNumber="+3538765987",ContactEmail="aedinlang@eircom.net" }

                };

            children.ForEach(c => context.Kids.Add(c));
            context.SaveChanges();

            //Populate Activity table
            var activities = new List<Activity>
            {
                new Activity { NameOfActivity="Gaelic football", DayOfActivity=Day.Monday,TimeOfActivity=DateTime.Parse("18:00:00"), ActivityPrice=65, InstructorFirstName="John", InstructorLastName="Smith", InstructorContactNumber="+353 87 1234567", InstructorEmail="johnoreilly@gmail.com", Description="Skills training done in a fun way aimed at children. Non competitive matches." },
                new Activity { NameOfActivity="Basketball", DayOfActivity=Day.Tuesday,TimeOfActivity=DateTime.Parse("14:30:00"), ActivityPrice=60, InstructorFirstName="Mary", InstructorLastName="Murphy", InstructorContactNumber="+353 85 2222222", InstructorEmail="marymurphy@hotmail.com", Description="Skills training done in a fun way aimed at children. Non competitive matches."},
                new Activity { NameOfActivity="Chess Club", DayOfActivity=Day.Wednesday,TimeOfActivity=DateTime.Parse("03:00:00"), ActivityPrice=60, InstructorFirstName="Kevin", InstructorLastName="Long", InstructorContactNumber="+353 87 7654321", InstructorEmail="kevinlong@eircom.net", Description="Learn the fundamentals of chess in a relaxed and fun environment."},
                new Activity { NameOfActivity="Irish Club", DayOfActivity=Day.Thursday,TimeOfActivity=DateTime.Parse("19:00:00"), ActivityPrice=45, InstructorFirstName="Ann", InstructorLastName="Dunne", InstructorContactNumber="+353 86 1222222", InstructorEmail="anndunne@gmail.com", Description="Play games and have fun through Irish"},
                new Activity { NameOfActivity="Soccer", DayOfActivity=Day.Friday,TimeOfActivity=DateTime.Parse("15:00:00"), ActivityPrice=50, InstructorFirstName="Frances", InstructorLastName="O'Reilly", InstructorContactNumber="+353 87 2333333", InstructorEmail="francesoreilly@gmail.com", Description="Skills training done in a fun way aimed at children. Non competitive matches."},
                new Activity { NameOfActivity="Irish Dancing", DayOfActivity=Day.Wednesday,TimeOfActivity=DateTime.Parse("20:00:00"), ActivityPrice=60, InstructorFirstName="Maeve", InstructorLastName="Warren", InstructorContactNumber="+353 87 7775666", InstructorEmail="maevewarren@hotmail.com", Description="Learn how to Irish dance in a fun environment"},
                new Activity { NameOfActivity="Swimming", DayOfActivity=Day.Saturday,TimeOfActivity=DateTime.Parse("08:00:00"), ActivityPrice=70, InstructorFirstName="Mark", InstructorLastName="Hynes", InstructorContactNumber="+353 87 9998887", InstructorEmail="markhynesn@yahoo.com", Description="Make sure your child can swim! All abilities catered for."}
            };

            activities.ForEach(a => context.Activities.Add(a));
            context.SaveChanges();

            //Populate Enrollment table   NOT INITIALIZING TABLE FOR SOME REASON???
            var enrollments = new List<Enrollment>
            {
                new Enrollment { KidID=1, ActivityID=3, PaymentDue=true},
                new Enrollment { KidID=0, ActivityID=1, PaymentDue=true },
                new Enrollment { KidID=0, ActivityID=0, PaymentDue=false },
                new Enrollment { KidID=2, ActivityID=0, PaymentDue=true },
                new Enrollment { KidID=1, ActivityID=2, PaymentDue=false },
                new Enrollment { KidID=2, ActivityID=6, PaymentDue=false }
            };

            /*enrollments.ForEach(e => context.Enrollments.Add(e));
            context.SaveChanges();*/
        }


    }
}