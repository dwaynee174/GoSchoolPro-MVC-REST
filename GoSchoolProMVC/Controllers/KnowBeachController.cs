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
    public class KnowBeachController : Controller
    {
        private GSProDbEntities db = new GSProDbEntities();

        // GET: KnowBeach
        public ActionResult Index()
        {
            var knowBeaches = db.KnowBeaches.Include(k => k.Student);
            return View(knowBeaches.ToList());
        }

        // GET: KnowBeach/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KnowBeach knowBeach = db.KnowBeaches.Find(id);
            if (knowBeach == null)
            {
                return HttpNotFound();
            }
            return View(knowBeach);
        }

        // GET: KnowBeach/Create
        public ActionResult Create()
        {
            ViewBag.KUserId = new SelectList(db.Students, "UserId", "Passwd");
            return View();
        }

        // POST: KnowBeach/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KnowBeachNo,CourseNumber,CourseName,Professor,Semester,CourseLoadFactor,CourseRating,ProfessorRating,KUserId")] KnowBeach knowBeach)
        {
            if (ModelState.IsValid)
            {
                db.KnowBeaches.Add(knowBeach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KUserId = new SelectList(db.Students, "UserId", "Passwd", knowBeach.KUserId);
            return View(knowBeach);
        }

        // GET: KnowBeach/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KnowBeach knowBeach = db.KnowBeaches.Find(id);
            if (knowBeach == null)
            {
                return HttpNotFound();
            }
            ViewBag.KUserId = new SelectList(db.Students, "UserId", "Passwd", knowBeach.KUserId);
            return View(knowBeach);
        }

        // POST: KnowBeach/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KnowBeachNo,CourseNumber,CourseName,Professor,Semester,CourseLoadFactor,CourseRating,ProfessorRating,KUserId")] KnowBeach knowBeach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(knowBeach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KUserId = new SelectList(db.Students, "UserId", "Passwd", knowBeach.KUserId);
            return View(knowBeach);
        }

        // GET: KnowBeach/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KnowBeach knowBeach = db.KnowBeaches.Find(id);
            if (knowBeach == null)
            {
                return HttpNotFound();
            }
            return View(knowBeach);
        }

        // POST: KnowBeach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KnowBeach knowBeach = db.KnowBeaches.Find(id);
            db.KnowBeaches.Remove(knowBeach);
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
