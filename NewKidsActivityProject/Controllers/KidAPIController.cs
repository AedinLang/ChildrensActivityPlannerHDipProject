using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using NewKidsActivityProject.DAL;
using NewKidsActivityProject.Models;

namespace NewKidsActivityProject.Controllers
{
    [RoutePrefix("kids")]
    public class KidAPIController : ApiController
    {
        private ActivityContext db = new ActivityContext();
        public KidAPIController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        
        [Route("all")]
        // GET: api/KidAPI
        public IHttpActionResult GetAllKids()
        {
            return Ok(db.Kids.ToList());
        }

        // GET: kids/id/{id}
        [Route("id/{id:int}")]
        [ResponseType(typeof(Kid))]
        public async Task<IHttpActionResult> GetKid(int id)
        {
            Kid kid = await db.Kids.FindAsync(id);
            if (kid == null)
            {
                return NotFound();
            }

            return Ok(kid);
        }

        
        [Route("lastname/{LastName}")]
        [ResponseType(typeof(Kid))]
        public async Task<IHttpActionResult> GetKidsByName(String lastname)
        {
            Kid kiddo = await db.Kids.FirstOrDefaultAsync(k => k.LastName.ToUpper() == lastname.ToUpper());
            if (kiddo == null)
            {
                return NotFound();
            }
            return Ok(kiddo);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KidExists(int id)
        {
            return db.Kids.Count(e => e.KidID == id) > 0;
        }
    }
}