using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewKidsActivityProject.DAL;
using NewKidsActivityProject.Models;

namespace NewKidsActivityProject.Controllers
{
    public class ActivityController : Controller
    {
        private ActivityContext db = new ActivityContext();

        // GET: Activity Names - activity name only, use in dropdown list for Activity
        public ActionResult AllActivities()
        {   
              return View(db.Activities.ToList().OrderBy(a=>a.NameOfActivity));
        }

        // GET: Activity Names - activity name only, use in dropdown list for Activity
        public ActionResult Enrollments()           //SAME CODE AS ABOVE MUST BE SOMEWAY OF CHOOSING WHICH "SECOND" VIEW TO GO TO BASED ON CONDITIONS
        {

            return View(db.Activities.OrderBy(a=>a.NameOfActivity).ToList());
        }

        // GET: Enrollment details - use when select Activity Enrollment from Enrollments dropdown

        public ActionResult EnrollmentsForActivity(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);

            var count = db.Enrollments.Count(a => a.ActivityID == id);

            ViewBag.NumberOfEnrollments = count;
            ViewBag.PlacesLeft = activity.Places - count;

            if (activity == null)
            {
                return HttpNotFound();
            }

            return View(activity);
        }


        //GET: Activity Details - use when select activity from dropdown list/All activities
        public ActionResult ActivityDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Activity activity = db.Activities.Find(id);

            var count = db.Enrollments.Count(a => a.ActivityID == id);

            ViewBag.NumberOfEnrollments = count;
            ViewBag.PlacesLeft = activity.Places - count;

            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // GET: Activity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Activity/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActivityID,Places,NameOfActivity,DayOfActivity,TimeOfActivityValue,ActivityPrice,InstructorFirstName,InstructorLastName,InstructorContactNumber,InstructorEmail,Description")] Activity activity)
        {
            if (db.Activities.Any(a => a.NameOfActivity == activity.NameOfActivity && a.TimeOfActivityValue == activity.TimeOfActivityValue && a.DayOfActivity == activity.DayOfActivity && a.TimeOfActivityValue == activity.TimeOfActivityValue && a.InstructorFirstName == activity.InstructorFirstName && a.InstructorLastName == activity.InstructorLastName))
            {
                return RedirectToAction("Duplicate");
            }
            else if (ModelState.IsValid)
            {
                db.Activities.Add(activity);
                db.SaveChanges();
                return RedirectToAction("ActivityDetails", new { id = activity.ActivityID });
            }

            return View(activity);
        }

        //  GET : duplicate message
        public ActionResult Duplicate()
        {
            return View();
        }

        //  Get: Activity/Edit - to edit an activity from the drop down menu
        public ActionResult EditActivity()
        {
            return View(db.Activities.OrderBy(a => a.NameOfActivity));
        }

        // GET: Activity/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: Activity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActivityID,Places,NameOfActivity,DayOfActivity,TimeOfActivityValue,ActivityPrice,InstructorFirstName,InstructorLastName,InstructorContactNumber,InstructorEmail,Description")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ActivityDetails", new { id = activity.ActivityID });
            }
            return View(activity);
        }

        //  Get: Activity/Remove - to remove an activity from the drop down menu
        public ActionResult RemoveActivity()
        {
            return View(db.Activities.OrderBy(a => a.NameOfActivity).ToList());
        }


        // GET: Activity/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: Activity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity activity = db.Activities.Find(id);
            db.Activities.Remove(activity);
            db.SaveChanges();
            return RedirectToAction("AllActivities");
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
