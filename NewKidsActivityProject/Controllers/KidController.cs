using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NewKidsActivityProject.DAL;
using NewKidsActivityProject.Models;
using System;

namespace NewKidsActivityProject.Controllers
{
    public class KidController : Controller
    {
        private ActivityContext db = new ActivityContext();

        public ActionResult AllKids()        //First name, last name and DOB only, order by LastName
        {
            return View(db.Kids.ToList().OrderBy(k=>k.LastName));
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
        public ActionResult Create([Bind(Include = "KidID,FirstName,LastName,Address,DOB,MedicalIssues,MedicalIntervention,GuardianFirstName,GuardianLastName,GuardianContactNumber,ContactEmail")] Kid child)
        {
            //Check for kid already in database

            if (db.Kids.Any(k => k.DOB == child.DOB && k.LastName == child.LastName && k.FirstName == child.FirstName && k.Address==child.Address && k.GuardianFirstName==child.GuardianFirstName&&k.GuardianLastName==child.GuardianLastName))
            {
                return RedirectToAction("Duplicate");    
            }
            else if (ModelState.IsValid)
            {
                db.Kids.Add(child);
                db.SaveChanges();
                return RedirectToAction("KidDetails", new { id = child.KidID });
            }

            return View(child);
        }

        //  GET : duplicate message
        public ActionResult Duplicate()
        {
            return View();
        }

        

        //  Get: Kid/Edit - to edit a kid from the drop down menu
        public ActionResult EditChild()
        {
            return View(db.Kids.ToList().OrderBy(k=>k.LastName));
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
                return RedirectToAction("KidDetails", new { id = kid.KidID });
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
