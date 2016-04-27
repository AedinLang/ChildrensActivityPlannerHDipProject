using System;
using System.Data.Entity;
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
        public ActivityAPIController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

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
            Activity activityName =  await db.Activities.FirstOrDefaultAsync(a => a.NameOfActivity.ToUpper() == nameOfActivity.ToUpper());
            if (activityName == null)
            {
                return NotFound();
            }
            return Ok(activityName);
        }

        //[Route("lastname/{LastName}")]
        //[ResponseType(typeof(Kid))]
        //public async Task<IHttpActionResult> GetKidsByName(String lastname)
        //{
        //    Kid kiddo = await db.Kids.FirstOrDefaultAsync(k => k.LastName.ToUpper() == lastname.ToUpper());
        //    if (kiddo == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(kiddo);

        //}


        /* [Route("name/{name}")]      //name and then that will add the name in the column, GET all/name/donal
         public IHttpActionResult GetName(string name)
         {
             PhoneBookEntry nameEntry = data.FirstOrDefault(n => n.Name.ToUpper() == name.ToUpper());
             if (nameEntry == null)
             {
                 return NotFound();
             }
             return Ok(nameEntry);
         }*/

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