using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NewKidsActivityProject.DAL;
using NewKidsActivityProject.Models;

namespace NewKidsActivityProject.Controllers
{
    public class KidController : Controller
    {
        private ActivityContext db = new ActivityContext();

        public ActionResult AllKids()        //First name, last name and DOB only
        {
            return View(db.Kids.ToList());
        }

        public ActionResult KidDetails(int? id)     //All details for kid's name selected including list of activities enrolled in
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kid kid = db.Kids.Find(id);
            if (kid == null)
            {
                return HttpNotFound();
            }
            return View(kid);
        }

        // GET: Kid  - different view to AllKids
        public ActionResult Index()
        {
            return View(db.Kids.ToList());
        }

        // GET: Kid/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kid kid = db.Kids.Find(id);
            if (kid == null)
            {
                return HttpNotFound();
            }
            return View(kid);
        }

        
        // GET: Kid/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kid/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KidID,FirstName,LastName,Address,DOB,MedicalIssues,MedicalIntervention,GuardianFirstName,GuardianLastName,GuardianContactNumber,ContactEmail")] Kid kid)
        {
            if (ModelState.IsValid)
            {
                db.Kids.Add(kid);
                db.SaveChanges();
                return RedirectToAction("AllKids");
            }

            return View(kid);
        }

        //  Get: Kid/Edit - to edit a kid from the drop down menu
        public ActionResult EditChild()
        {
            return View(db.Kids.ToList());
        }


        // GET: Kid/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kid kid = db.Kids.Find(id);
            if (kid == null)
            {
                return HttpNotFound();
            }
            return View(kid);
        }

        // POST: Kid/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KidID,FirstName,LastName,Address,DOB,MedicalIssues,MedicalIntervention,GuardianFirstName,GuardianLastName,GuardianContactNumber,ContactEmail")] Kid kid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AllKids");
            }
            return View(kid);
        }

        //  Get: Kid/Remove - to remove a kid from the drop down menu
        public ActionResult RemoveChild()
        {
            return View(db.Kids.ToList());
        }

        // GET: Kid/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kid kid = db.Kids.Find(id);
            if (kid == null)
            {
                return HttpNotFound();
            }
            return View(kid);
        }

        // POST: Kid/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kid kid = db.Kids.Find(id);
            db.Kids.Remove(kid);
            db.SaveChanges();
            return RedirectToAction("AllKids");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
