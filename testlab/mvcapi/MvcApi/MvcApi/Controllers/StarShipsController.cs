using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcApi.Models;

namespace MvcApi.Controllers
{
    public class StarShipsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StarShips
        public ActionResult Index()
        {
            return View(db.StarShips.ToList());
        }

        // GET: StarShips/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StarShip starShip = db.StarShips.Find(id);
            if (starShip == null)
            {
                return HttpNotFound();
            }
            return View(starShip);
        }

        // GET: StarShips/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StarShips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CostInCredits,hyper_drive_rating")] StarShip starShip)
        {
            if (ModelState.IsValid)
            {
                db.StarShips.Add(starShip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(starShip);
        }

        // GET: StarShips/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StarShip starShip = db.StarShips.Find(id);
            if (starShip == null)
            {
                return HttpNotFound();
            }
            return View(starShip);
        }

        // POST: StarShips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CostInCredits,hyper_drive_rating")] StarShip starShip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(starShip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(starShip);
        }

        // GET: StarShips/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StarShip starShip = db.StarShips.Find(id);
            if (starShip == null)
            {
                return HttpNotFound();
            }
            return View(starShip);
        }

        // POST: StarShips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StarShip starShip = db.StarShips.Find(id);
            db.StarShips.Remove(starShip);
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
