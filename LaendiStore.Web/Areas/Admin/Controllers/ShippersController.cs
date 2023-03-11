using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LaendiStore.Data.DBContext;
using LaendiStore.Data.EF;

namespace LaendiStore.Web.Areas.Admin.Controllers
{
    public class ShippersController : Controller
    {
        private eLaendiStoreDBContext db = new eLaendiStoreDBContext();

        // GET: Admin/Shippers
        public ActionResult Index()
        {
            var shippers = db.Shippers.Include(s => s.Store);
            return View(shippers.ToList());
        }

        // GET: Admin/Shippers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipper shipper = db.Shippers.Find(id);
            if (shipper == null)
            {
                return HttpNotFound();
            }
            return View(shipper);
        }

        // GET: Admin/Shippers/Create
        public ActionResult Create()
        {
            ViewBag.StoreID = new SelectList(db.Stores, "StoreID", "StoreName");
            return View();
        }

        // POST: Admin/Shippers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShipperID,ShipperName,Company,NumberPhone,StoreID")] Shipper shipper)
        {
            if (ModelState.IsValid)
            {
                db.Shippers.Add(shipper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StoreID = new SelectList(db.Stores, "StoreID", "StoreName", shipper.StoreID);
            return View(shipper);
        }

        // GET: Admin/Shippers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipper shipper = db.Shippers.Find(id);
            if (shipper == null)
            {
                return HttpNotFound();
            }
            ViewBag.StoreID = new SelectList(db.Stores, "StoreID", "StoreName", shipper.StoreID);
            return View(shipper);
        }

        // POST: Admin/Shippers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShipperID,ShipperName,Company,NumberPhone,StoreID")] Shipper shipper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StoreID = new SelectList(db.Stores, "StoreID", "StoreName", shipper.StoreID);
            return View(shipper);
        }

        // GET: Admin/Shippers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipper shipper = db.Shippers.Find(id);
            if (shipper == null)
            {
                return HttpNotFound();
            }
            return View(shipper);
        }

        // POST: Admin/Shippers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shipper shipper = db.Shippers.Find(id);
            db.Shippers.Remove(shipper);
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
