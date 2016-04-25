using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using NewKidsActivityProject.DAL;
using NewKidsActivityProject.Models;

namespace NewKidsActivityProject.Controllers
{
    [RoutePrefix("activities")]
    public class ActivityAPIController : ApiController
    {
        private ActivityContext db = new ActivityContext();

        [Route("all")]
        // GET: api/ActivityAPI
        public IHttpActionResult GetAllActivities()
        {
            return Ok(db.Activities.ToList());
        }
        [Route("id/{id:int}")]
        // GET: api/ActivityAPI/5
        [ResponseType(typeof(Activity))]
        public async Task<IHttpActionResult> GetActivity(int id)
        {
            Activity activity = await db.Activities.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }

        [Route("activityName/{NameOfActivity}")]
        [ResponseType(typeof(Activity))]
        public async Task<IHttpActionResult> GetActivityByName(String nameOfActivity)
        {
            var activityName = await db.Activities.FindAsync(nameOfActivity);
            if (activityName == null)
            {
                return NotFound();
            }
            return Ok(activityName);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActivityExists(int id)
        {
            return db.Activities.Count(e => e.ActivityID == id) > 0;
        }
    }
}