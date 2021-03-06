﻿using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NewKidsActivityProject.DAL;
using NewKidsActivityProject.Models;

namespace NewKidsActivityProject.Controllers
{
    public class EnrollmentController : Controller
    {
        private ActivityContext db = new ActivityContext();

        // GET: Enrollment
        public ActionResult Index()
        {
            var enrollments = db.Enrollments.Include(e => e.Activity).Include(e => e.Kid).OrderBy(e=>e.Kid.LastName);       //Alphabetically sort by Kid lastname
            return View(enrollments.ToList());
        }

        // GET: Enrollment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // GET: Enrollment/Create
        public ActionResult Create()
        {
            ViewBag.ActivityID = new SelectList(db.Activities, "ActivityID", "NameOfActivity");
            ViewBag.KidID = new SelectList(db.Kids, "KidID", "FullName");
            return View();
        }

        
        // POST: Enrollment/Create
        // To protect from overposting attacks, enable properties you want to bind to 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnrollmentID,KidID,ActivityID,PaymentDue")] Enrollment enrollment)
        {
            if (db.Enrollments.Any(e => e.KidID == enrollment.KidID && e.ActivityID == enrollment.ActivityID))
            {
                return RedirectToAction("Duplicate");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    db.Enrollments.Add(enrollment);
                    db.SaveChanges();
                    return RedirectToAction("ActivityDetails", "Activity", new { id = enrollment.ActivityID });
                }

                ViewBag.ActivityID = new SelectList(db.Activities, "ActivityID", "NameOfActivity", enrollment.ActivityID);
                ViewBag.KidID = new SelectList(db.Kids, "KidID", "FullName", enrollment.KidID);
            }
            catch(DataException /*Dex*/)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(enrollment);
        }


       
        //  GET : duplicate message
        public ActionResult Duplicate()
        {
            return View();
        }

        // GET: EditEnrollment - dropdown on Homescreen
        public ActionResult EditEnrollment()
        {
            var enrollments = db.Enrollments.Include(e => e.Activity).Include(e => e.Kid).OrderBy(e=>e.Activity.NameOfActivity);     //Activities listed in alphabetical order
            return View(enrollments.ToList());
        }

        // GET: Enrollment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivityID = new SelectList(db.Activities, "ActivityID", "NameOfActivity", enrollment.ActivityID);
            ViewBag.KidID = new SelectList(db.Kids, "KidID", "FullName", enrollment.KidID);
            return View(enrollment);
        }

        
        // POST: Enrollment/Edit
        //This code allows update of the PaymentDue field only. This is the only field in an enrollment that should be edited.

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var enrollmentToUpdate = db.Enrollments.Find(id);
            if (TryUpdateModel(enrollmentToUpdate, "",
               new string[] { "KidID", "ActivityID", "PaymentDue" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("EditEnrollment");//, "Activity", new { id = enrollmentToUpdate.ActivityID });
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(enrollmentToUpdate);
        }

        // GET: DeleteEnrollment - dropdown on Homescreen
        public ActionResult DeleteEnrollment()
        {
            var enrollments = db.Enrollments.Include(e => e.Activity).Include(e => e.Kid).OrderBy(e => e.Activity.NameOfActivity);     //Activities listed in alphabetical order
            return View(enrollments.ToList());
        }

        // GET: Enrollment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // POST: Enrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Enrollment enrollment = db.Enrollments.Find(id);
                db.Enrollments.Remove(enrollment);
                db.SaveChanges();
                return RedirectToAction("EnrollmentsForActivity", "Activity", new { id = enrollment.ActivityID });
            }
            catch(DataException /*Dex*/)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View();
                  
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
