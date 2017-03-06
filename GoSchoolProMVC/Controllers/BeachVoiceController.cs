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
    public class BeachVoiceController : Controller
    {
        private GSProDbEntities db = new GSProDbEntities();

        // GET: BeachVoice
        public ActionResult Index()
        {
            var beachVoices = db.BeachVoices.Include(b => b.Student);
            return View(beachVoices.ToList());
        }

        // GET: BeachVoice/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeachVoice beachVoice = db.BeachVoices.Find(id);
            if (beachVoice == null)
            {
                return HttpNotFound();
            }
            return View(beachVoice);
        }

        // GET: BeachVoice/Create
        public ActionResult Create()
        {
            ViewBag.BUserId = new SelectList(db.Students, "UserId", "FName");
            return View();
        }

        // POST: BeachVoice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BeachVoiceId,Question,QuestionCategory,Answer,BUserId")] BeachVoice beachVoice)
        {
            if (ModelState.IsValid)
            {
                db.BeachVoices.Add(beachVoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BUserId = new SelectList(db.Students, "UserId", "FName", beachVoice.BUserId);
            return View(beachVoice);
        }

        // GET: BeachVoice/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeachVoice beachVoice = db.BeachVoices.Find(id);
            if (beachVoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.BUserId = new SelectList(db.Students, "UserId", "FName", beachVoice.BUserId);
            return View(beachVoice);
        }

        // POST: BeachVoice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BeachVoiceId,Question,QuestionCategory,Answer,BUserId")] BeachVoice beachVoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beachVoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BUserId = new SelectList(db.Students, "UserId", "FName", beachVoice.BUserId);
            return View(beachVoice);
        }

        // GET: BeachVoice/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeachVoice beachVoice = db.BeachVoices.Find(id);
            if (beachVoice == null)
            {
                return HttpNotFound();
            }
            return View(beachVoice);
        }

        // POST: BeachVoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BeachVoice beachVoice = db.BeachVoices.Find(id);
            db.BeachVoices.Remove(beachVoice);
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
