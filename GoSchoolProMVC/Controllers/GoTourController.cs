using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoSchoolProMVC.Models.DB;

namespace GoSchoolProMVC.Controllers
{
    public class GoTourController : Controller
    {
        private GSProDbEntities db = new GSProDbEntities();

        // GET: GoTour
        public ActionResult Index()
        {
            var goTours = db.GoTours.Include(g => g.Student);
            return View(goTours.ToList());
        }

        // GET: GoTour/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoTour goTour = db.GoTours.Find(id);
            if (goTour == null)
            {
                return HttpNotFound();
            }
            return View(goTour);
        }

        // GET: GoTour/Create
        public ActionResult Create()
        {
            ViewBag.GTUserId = new SelectList(db.Students, "UserId", "Passwd");
            return View();
        }

        // POST: GoTour/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TourId,FName,LName,Contact,EmailId,TourDate,TourTime,TourType,GTUserId")] GoTour goTour)
        {
            if (ModelState.IsValid)
            {
                db.GoTours.Add(goTour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GTUserId = new SelectList(db.Students, "UserId", "Passwd", goTour.GTUserId);
            return View(goTour);
        }

        // GET: GoTour/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoTour goTour = db.GoTours.Find(id);
            if (goTour == null)
            {
                return HttpNotFound();
            }
            ViewBag.GTUserId = new SelectList(db.Students, "UserId", "Passwd", goTour.GTUserId);
            return View(goTour);
        }

        // POST: GoTour/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TourId,FName,LName,Contact,EmailId,TourDate,TourTime,TourType,GTUserId")] GoTour goTour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goTour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GTUserId = new SelectList(db.Students, "UserId", "Passwd", goTour.GTUserId);
            return View(goTour);
        }

        // GET: GoTour/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoTour goTour = db.GoTours.Find(id);
            if (goTour == null)
            {
                return HttpNotFound();
            }
            return View(goTour);
        }

        // POST: GoTour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GoTour goTour = db.GoTours.Find(id);
            db.GoTours.Remove(goTour);
            db.SaveChanges();
            return RedirectToAction("Index");
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
