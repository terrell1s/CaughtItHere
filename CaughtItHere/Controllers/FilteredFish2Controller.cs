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
    public class FilteredFish2Controller : Controller
    {
        private CaughtItHereEntities db = new CaughtItHereEntities();

        // GET: FilteredFish2
        public ActionResult Index()
        {
            var exisitingFish = db.Fish;

            var checkFish = from f in db.FishTypes
                            select f;

            return View(exisitingFish);
        }

        // GET: FilteredFish2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fish fish = db.Fish.Find(id);
            if (fish == null)
            {
                return HttpNotFound();
            }
            return View(fish);
        }

        // GET: FilteredFish2/Create
        public ActionResult Create()
        {
            ViewBag.FishTypeId = new SelectList(db.FishTypes, "Id", "Name");
            return View();
        }

        // POST: FilteredFish2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FishTypeId,Length,Image,LureType,ImageLure,Comment,TimeDate,Latitude,Longitude,Weight")] Fish fish)
        {
            if (ModelState.IsValid)
            {
                db.Fish.Add(fish);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FishTypeId = new SelectList(db.FishTypes, "Id", "Name", fish.FishTypeId);
            return View(fish);
        }

        // GET: FilteredFish2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fish fish = db.Fish.Find(id);
            if (fish == null)
            {
                return HttpNotFound();
            }
            ViewBag.FishTypeId = new SelectList(db.FishTypes, "Id", "Name", fish.FishTypeId);
            return View(fish);
        }

        // POST: FilteredFish2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FishTypeId,Length,Image,LureType,ImageLure,Comment,TimeDate,Latitude,Longitude,Weight")] Fish fish)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fish).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FishTypeId = new SelectList(db.FishTypes, "Id", "Name", fish.FishTypeId);
            return View(fish);
        }

        // GET: FilteredFish2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fish fish = db.Fish.Find(id);
            if (fish == null)
            {
                return HttpNotFound();
            }
            return View(fish);
        }

        // POST: FilteredFish2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fish fish = db.Fish.Find(id);
            db.Fish.Remove(fish);
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
