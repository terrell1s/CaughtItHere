using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CaughtItHere;

namespace CaughtItHere.Controllers
{
    public class FishTypesController : Controller
    {
        private CaughtItHereEntities db = new CaughtItHereEntities();

        // GET: FishTypes
        public ActionResult Index()
        {
            return View(db.FishTypes.ToList());
        }

        // GET: FishTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FishType fishType = db.FishTypes.Find(id);
            if (fishType == null)
            {
                return HttpNotFound();
            }
            return View(fishType);
        }

        // GET: FishTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FishTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] FishType fishType)
        {
            if (ModelState.IsValid)
            {
                db.FishTypes.Add(fishType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fishType);
        }

        // GET: FishTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FishType fishType = db.FishTypes.Find(id);
            if (fishType == null)
            {
                return HttpNotFound();
            }
            return View(fishType);
        }

        // POST: FishTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] FishType fishType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fishType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fishType);
        }

        // GET: FishTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FishType fishType = db.FishTypes.Find(id);
            if (fishType == null)
            {
                return HttpNotFound();
            }
            return View(fishType);
        }

        // POST: FishTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FishType fishType = db.FishTypes.Find(id);
            db.FishTypes.Remove(fishType);
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
