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
    public class AirportPckUpController : Controller
    {
        private GSProDbEntities db = new GSProDbEntities();

        // GET: AirportPckUp
        public ActionResult Index()
        {
            var airportPckUps = db.AirportPckUps.Include(a => a.Student);
            return View(airportPckUps.ToList());
        }

        // GET: AirportPckUp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirportPckUp airportPckUp = db.AirportPckUps.Find(id);
            if (airportPckUp == null)
            {
                return HttpNotFound();
            }
            return View(airportPckUp);
        }

        // GET: AirportPckUp/Create
        public ActionResult Create()
        {
            ViewBag.APUserId = new SelectList(db.Students, "UserId", "Passwd");
            return View();
        }

        // POST: AirportPckUp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlightNo,FName,LName,Contact,EmailId,Address,ArrivalAirport,FlightName,ArrivalDate,ArrivalTime,APUserId")] AirportPckUp airportPckUp)
        {
            if (ModelState.IsValid)
            {
                db.AirportPckUps.Add(airportPckUp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.APUserId = new SelectList(db.Students, "UserId", "Passwd", airportPckUp.APUserId);
            return View(airportPckUp);
        }

        // GET: AirportPckUp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirportPckUp airportPckUp = db.AirportPckUps.Find(id);
            if (airportPckUp == null)
            {
                return HttpNotFound();
            }
            ViewBag.APUserId = new SelectList(db.Students, "UserId", "Passwd", airportPckUp.APUserId);
            return View(airportPckUp);
        }

        // POST: AirportPckUp/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FlightNo,FName,LName,Contact,EmailId,Address,ArrivalAirport,FlightName,ArrivalDate,ArrivalTime,APUserId")] AirportPckUp airportPckUp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airportPckUp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.APUserId = new SelectList(db.Students, "UserId", "Passwd", airportPckUp.APUserId);
            return View(airportPckUp);
        }

        // GET: AirportPckUp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirportPckUp airportPckUp = db.AirportPckUps.Find(id);
            if (airportPckUp == null)
            {
                return HttpNotFound();
            }
            return View(airportPckUp);
        }

        // POST: AirportPckUp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AirportPckUp airportPckUp = db.AirportPckUps.Find(id);
            db.AirportPckUps.Remove(airportPckUp);
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
