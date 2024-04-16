using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Oil2UAdmin;

namespace Oil2UAdmin.Controllers
{
    public class UrgentDeliveryController : Controller
    {
        private Oil2UEntities db = new Oil2UEntities();

        // GET: UrgentDeliveries
        public ActionResult Index()
        {
            var urgentDeliveries = db.UrgentDeliveries.Include(u => u.User);
            return View(urgentDeliveries.ToList());
        }

        // GET: UrgentDeliveries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrgentDelivery urgentDelivery = db.UrgentDeliveries.Find(id);
            if (urgentDelivery == null)
            {
                return HttpNotFound();
            }
            return View(urgentDelivery);
        }

        // GET: UrgentDeliveries/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName");
            return View();
        }

        // POST: UrgentDeliveries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UrgentRequestId,OrderId,Quantity,DeliveryDate,UserId,ReferenceEmail,ReferencePhoneNo")] UrgentDelivery urgentDelivery)
        {
            if (ModelState.IsValid)
            {
                db.UrgentDeliveries.Add(urgentDelivery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName", urgentDelivery.UserId);
            return View(urgentDelivery);
        }

        // GET: UrgentDeliveries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrgentDelivery urgentDelivery = db.UrgentDeliveries.Find(id);
            if (urgentDelivery == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName", urgentDelivery.UserId);
            return View(urgentDelivery);
        }

        // POST: UrgentDeliveries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UrgentRequestId,OrderId,Quantity,DeliveryDate,UserId,ReferenceEmail,ReferencePhoneNo")] UrgentDelivery urgentDelivery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urgentDelivery).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName", urgentDelivery.UserId);
            return View(urgentDelivery);
        }

        // GET: UrgentDeliveries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrgentDelivery urgentDelivery = db.UrgentDeliveries.Find(id);
            if (urgentDelivery == null)
            {
                return HttpNotFound();
            }
            return View(urgentDelivery);
        }

        // POST: UrgentDeliveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UrgentDelivery urgentDelivery = db.UrgentDeliveries.Find(id);
            db.UrgentDeliveries.Remove(urgentDelivery);
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
