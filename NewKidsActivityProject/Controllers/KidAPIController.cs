using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using NewKidsActivityProject.DAL;
using NewKidsActivityProject.Models;

namespace NewKidsActivityProject.Controllers
{
    public class KidAPIController : ApiController
    {
        private ActivityContext db = new ActivityContext();

        // GET: api/KidAPI
        public IQueryable<Kid> GetKids()
        {
            return db.Kids;
        }

        // GET: api/KidAPI/5
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

        // PUT: api/KidAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutKid(int id, Kid kid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kid.KidID)
            {
                return BadRequest();
            }

            db.Entry(kid).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KidExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/KidAPI
        [ResponseType(typeof(Kid))]
        public async Task<IHttpActionResult> PostKid(Kid kid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kids.Add(kid);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = kid.KidID }, kid);
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