using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MealTimeOnline.DataAccessLayer;
using MealTimeOnline.Models.Dealer;

namespace MealTimeOnline.Areas.Admin.Controllers
{
    public class CanteenCategoriesController : Controller
    {
        private MtoDataContext db = new MtoDataContext();

        // GET: Admin/CanteenCategories
        public ActionResult Index()
        {
            return View(db.CanteenCategories.ToList());
        }

        // GET: Admin/CanteenCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CanteenCategory canteenCategory = db.CanteenCategories.Find(id);
            if (canteenCategory == null)
            {
                return HttpNotFound();
            }
            return View(canteenCategory);
        }

        // GET: Admin/CanteenCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CanteenCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CanteenCategoryId,Value")] CanteenCategory canteenCategory)
        {
            if (ModelState.IsValid)
            {
                db.CanteenCategories.Add(canteenCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(canteenCategory);
        }

        // GET: Admin/CanteenCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CanteenCategory canteenCategory = db.CanteenCategories.Find(id);
            if (canteenCategory == null)
            {
                return HttpNotFound();
            }
            return View(canteenCategory);
        }

        // POST: Admin/CanteenCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CanteenCategoryId,Value")] CanteenCategory canteenCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(canteenCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(canteenCategory);
        }

        // GET: Admin/CanteenCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CanteenCategory canteenCategory = db.CanteenCategories.Find(id);
            if (canteenCategory == null)
            {
                return HttpNotFound();
            }
            return View(canteenCategory);
        }

        // POST: Admin/CanteenCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CanteenCategory canteenCategory = db.CanteenCategories.Find(id);
            db.CanteenCategories.Remove(canteenCategory);
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
