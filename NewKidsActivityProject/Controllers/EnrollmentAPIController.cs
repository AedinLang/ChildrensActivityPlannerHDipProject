using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Routing;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using NewKidsActivityProject.DAL;
using NewKidsActivityProject.Models;

namespace NewKidsActivityProject.Controllers
{
    [RoutePrefix("enrolments")]
    public class EnrollmentAPIController : ApiController
    {
        private ActivityContext db = new ActivityContext();
        public EnrollmentAPIController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        [Route("all")]
        // GET: enrolments/all
        public IHttpActionResult GetAllEnrollments()
        {
            return Ok(db.Enrollments.ToList());
        }

        // GET: api/EnrollmentAPI/5
        [Route("id/{id:int}")]
        [ResponseType(typeof(Enrollment))]
        public async Task<IHttpActionResult> GetEnrollment(int id)
        {
            Enrollment enrollment = await db.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return Ok(enrollment);
        }
        
        //get activitiesPerChild
        [Route("allActivities/fullname/{FirstName}/{LastName}")]
        [HttpGet]
        public IHttpActionResult AllActivitiesForChild(string firstname, string lastname)
        {
            var activitiesPerChild = (from k in db.Kids
                                      join e in db.Enrollments on k.KidID equals e.KidID
                                      join a in db.Activities on e.ActivityID equals a.ActivityID
                                      where  k.FirstName == firstname && k.LastName == lastname 
                                      select  a.NameOfActivity).ToList();
                                      //select  (a.NameOfActivity) );
            
            if (activitiesPerChild == null)
            {
                return NotFound();
            }
            else
            {
                
                    return Ok(activitiesPerChild.ToList());

            }

            // return Ok(activitiesPerChild.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EnrollmentExists(int id)
        {
            return db.Enrollments.Count(e => e.EnrollmentID == id) > 0;
        }
    }
}