using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CaughtItHere;
using CaughtItHere.Models;

namespace CaughtItHere.Controllers
{
    public class FishController : Controller
    {
        private CaughtItHereEntities db = new CaughtItHereEntities();

        //GET: Fish/byFishType
        public ActionResult FishByType()
        {
            var fish = db.Fish.Include(f => f.FishType);
            return View(fish.ToList());
        }
        // GET: Fish
        public ActionResult Index(string searchString, string searchString2)
        {
            var fishes = from f in db.Fish
                         select f;

            if (!String.IsNullOrEmpty(searchString))
            {
                fishes = fishes.Where(f => f.FishTypeId.ToString().ToUpper().Contains(searchString.ToUpper()));
               // fishes = fishes.Where(f => f.Latitude.ToString().ToUpper().Contains(searchString.ToUpper()));

            }

            if (!String.IsNullOrEmpty(searchString2))
            {
                fishes = fishes.Where(f => f.TimeDate.ToString().ToUpper().Contains(searchString2.ToUpper()));
                // fishes = fishes.Where(f => f.Latitude.ToString().ToUpper().Contains(searchString2.ToUpper()));

            }

            return View(fishes.ToList());

            //var fish = db.Fish.Include(f => f.FishType);
            //return View(fish.ToList());
        }

        // GET: Fish/Details/5
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

        // GET: Fish/Create

        public ActionResult Create(double fishLat, double fishLng)
        {


            ViewBag.FishTypeId = new SelectList(db.FishTypes, "Id", "Name");

            var fish = new Fish();
            fish.Latitude = fishLat;
            fish.Longitude = fishLng;

           return View(fish);
        }

        // POST: Fish/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FishTypeId,Length,Weight,Image,LureType,ImageLure,Comment,TimeDate,Latitude,Longitude")] Fish fish)
        {
            if (ModelState.IsValid)
            {
                db.Fish.Add(fish);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.FishTypeId = new SelectList(db.FishTypes, "Id", "Name", fish.FishTypeId);
            return View(fish);
        }

        // GET: Fish/Edit/5
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

        // POST: Fish/Edit/5
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

        // GET: Fish/Delete/5
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

        // POST: Fish/Delete/5
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

        public ActionResult DNR()
        {
            return Redirect("http://www.mdnr-elicense.com/Welcome/Default.aspx");
        }

        public ActionResult Regulations()
        {
            return Redirect("http://www.eregulations.com/wp-content/uploads/2014/01/14MIFW-FINAL-LR.pdf");
        }
    }
}
