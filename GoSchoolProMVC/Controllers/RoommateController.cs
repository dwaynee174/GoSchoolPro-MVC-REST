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
    public class RoommateController : Controller
    {
        private GSProDbEntities db = new GSProDbEntities();

        // GET: Roommate
        public ActionResult Index()
        {
            var roommates = db.Roommates.Include(r => r.Student);
            return View(roommates.ToList());
        }

        // GET: Roommate/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roommate roommate = db.Roommates.Find(id);
            if (roommate == null)
            {
                return HttpNotFound();
            }
            return View(roommate);
        }

        // GET: Roommate/Create
        public ActionResult Create()
        {
            ViewBag.RUserId = new SelectList(db.Students, "UserId", "Passwd");
            return View();
        }

        // POST: Roommate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RmId,Gender,Age,Program,Rent,Distance,Sharing,Pets,Socially,Cleanliness,Smoking,Working,RUserId")] Roommate roommate)
        {
            if (ModelState.IsValid)
            {
                db.Roommates.Add(roommate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RUserId = new SelectList(db.Students, "UserId", "Passwd", roommate.RUserId);
            return View(roommate);
        }

        // GET: Roommate/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roommate roommate = db.Roommates.Find(id);
            if (roommate == null)
            {
                return HttpNotFound();
            }
            ViewBag.RUserId = new SelectList(db.Students, "UserId", "Passwd", roommate.RUserId);
            return View(roommate);
        }

        // POST: Roommate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RmId,Gender,Age,Program,Rent,Distance,Sharing,Pets,Socially,Cleanliness,Smoking,Working,RUserId")] Roommate roommate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roommate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RUserId = new SelectList(db.Students, "UserId", "Passwd", roommate.RUserId);
            return View(roommate);
        }

        // GET: Roommate/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roommate roommate = db.Roommates.Find(id);
            if (roommate == null)
            {
                return HttpNotFound();
            }
            return View(roommate);
        }

        // POST: Roommate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Roommate roommate = db.Roommates.Find(id);
            db.Roommates.Remove(roommate);
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
