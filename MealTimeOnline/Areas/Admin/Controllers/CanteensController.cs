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
    public class CanteensController : Controller
    {
        private MtoDataContext db = new MtoDataContext();

        // GET: Admin/Canteens
        public ActionResult Index()
        {
            var canteens = db.Canteens.Include(c => c.CanteenCategory);
            return View(canteens.ToList());
        }

        // GET: Admin/Canteens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Canteen canteen = db.Canteens.Find(id);
            if (canteen == null)
            {
                return HttpNotFound();
            }
            return View(canteen);
        }

        // GET: Admin/Canteens/Create
        public ActionResult Create()
        {
            ViewBag.CanteenCategoryId = new SelectList(db.CanteenCategories, "CanteenCategoryId", "Value");
            return View();
        }

        // POST: Admin/Canteens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CanteenId,CanteenName,CanteenAddress,CanteenCategoryId,ServicePrice,CanteenInfo,SendWay,ShopHours,Notice,UseTime,EvaluateNum,SellNum,Images")] Canteen canteen)
        {
            if (ModelState.IsValid)
            {
                canteen.EvaluateNum = 5;
                db.Canteens.Add(canteen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CanteenCategoryId = new SelectList(db.CanteenCategories, "CanteenCategoryId", "Value", canteen.CanteenCategoryId);
            return View(canteen);
        }

        // GET: Admin/Canteens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Canteen canteen = db.Canteens.Find(id);
            if (canteen == null)
            {
                return HttpNotFound();
            }
            ViewBag.CanteenCategoryId = new SelectList(db.CanteenCategories, "CanteenCategoryId", "Value", canteen.CanteenCategoryId);
            return View(canteen);
        }

        // POST: Admin/Canteens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CanteenId,CanteenName,CanteenAddress,CanteenCategoryId,ServicePrice,CanteenInfo,SendWay,ShopHours,Notice,UseTime,EvaluateNum,SellNum,Images")] Canteen canteen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(canteen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CanteenCategoryId = new SelectList(db.CanteenCategories, "CanteenCategoryId", "Value", canteen.CanteenCategoryId);
            return View(canteen);
        }

        // GET: Admin/Canteens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Canteen canteen = db.Canteens.Find(id);
            if (canteen == null)
            {
                return HttpNotFound();
            }
            return View(canteen);
        }

        // POST: Admin/Canteens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Canteen canteen = db.Canteens.Find(id);
            db.Canteens.Remove(canteen);
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
