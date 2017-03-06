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
    public class ApartmentController : Controller
    {
        private GSProDbEntities db = new GSProDbEntities();
        public ActionResult SearchIndex(string bedGenre,string searchString)
        {
            var BedLst = new List<string>();

            var BedQry = from d in db.Apartments
                           orderby d.BedsxBath
                           select d.BedsxBath;
            BedLst.AddRange(BedQry.Distinct());
            ViewBag.bedGenre = new SelectList(BedLst);

            var apt = from m in db.Apartments
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                apt = apt.Where(s => s.BedsxBath.Contains(searchString));
            }

            if (string.IsNullOrEmpty(bedGenre))
                return View(apt);
            else
            {
                return View(apt.Where(x => x.BedsxBath == bedGenre));
            }

        }
        // GET: Apartment
        public ActionResult Index()
        {
            var apartments = db.Apartments.Include(a => a.Student);
            return View(apartments.ToList());
        }

        // GET: Apartment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartment apartment = db.Apartments.Find(id);
            if (apartment == null)
            {
                return HttpNotFound();
            }
            return View(apartment);
        }

        // GET: Apartment/Create
        public ActionResult Create()
        {
            ViewBag.AUserId = new SelectList(db.Students, "UserId", "Passwd");
            return View();
        }

        // POST: Apartment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AptId,Location,RentRange,BedsxBath,Parking,Preferences,AUserId")] Apartment apartment)
        {
            if (ModelState.IsValid)
            {
                db.Apartments.Add(apartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AUserId = new SelectList(db.Students, "UserId", "Passwd", apartment.AUserId);
            return View(apartment);
        }

        // GET: Apartment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartment apartment = db.Apartments.Find(id);
            if (apartment == null)
            {
                return HttpNotFound();
            }
            ViewBag.AUserId = new SelectList(db.Students, "UserId", "Passwd", apartment.AUserId);
            return View(apartment);
        }

        // POST: Apartment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AptId,Location,RentRange,BedsxBath,Parking,Preferences,AUserId")] Apartment apartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AUserId = new SelectList(db.Students, "UserId", "Passwd", apartment.AUserId);
            return View(apartment);
        }

        // GET: Apartment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartment apartment = db.Apartments.Find(id);
            if (apartment == null)
            {
                return HttpNotFound();
            }
            return View(apartment);
        }

        // POST: Apartment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Apartment apartment = db.Apartments.Find(id);
            db.Apartments.Remove(apartment);
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
