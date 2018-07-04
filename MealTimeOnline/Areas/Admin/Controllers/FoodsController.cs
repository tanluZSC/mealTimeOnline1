using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MealTimeOnline.DataAccessLayer;
using MealTimeOnline.Models.Commodity;

namespace MealTimeOnline.Areas.Admin.Controllers
{
    [RoutePrefix("Admin/Canteens/")]
    public class FoodsController : Controller
    {
        private MtoDataContext db = new MtoDataContext();

        // GET: Admin/Canteens/{cid}/Foods
        public ActionResult Index(int cid)
        {
            var canteen = db.Canteens.Find(cid);
            if (canteen == null)
            {
                return HttpNotFound();
            }
            var foods = db.Foods.Where(c => c.CanteenId == cid).Include(f => f.Canteen).Include(f => f.FoodCategory).Include(f => f.PeopleCategory);
            return View(foods.ToList());
        }

        // GET: Admin/Canteens/{cid}/Foods/Details/5
        public ActionResult Details(int cid, long? id)
        {
            if (db.Canteens.Find(cid) == null)
            {
                return HttpNotFound();
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        // GET: Admin/Canteens/{cid}/Foods/Create
        public ActionResult Create(int cid)
        {
            if (db.Canteens.Find(cid) == null)
            {
                return HttpNotFound();
            }

            ViewBag.FoodCategoryId = new SelectList(db.FoodCategories, "FoodCategoryId", "Value");
            ViewBag.PeopleCategoryId = new SelectList(db.PeopleCategories, "PeopleCategoryId", "Value");
            return View();
        }

        // POST: Admin/Canteens/{cid}/Foods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int cid, [Bind(Include = "FoodId,FoodCategoryId,PeopleCategoryId,FoodName,Price,Discount,FoodElement,FoodNutrition,CanteenId,Images")] Food food)
        {
            var canteen = db.Canteens.Find(cid);
            if (canteen == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                food.CanteenId = cid;
                db.Foods.Add(food);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FoodCategoryId = new SelectList(db.FoodCategories, "FoodCategoryId", "Value", food.FoodCategoryId);
            ViewBag.PeopleCategoryId = new SelectList(db.PeopleCategories, "PeopleCategoryId", "Value", food.PeopleCategoryId);
            return View(food);
        }

        // GET: Admin/Canteens/{cid}/Foods/Edit/5
        public ActionResult Edit(int cid, long? id)
        {
            if (db.Canteens.Find(cid) == null)
            {
                return HttpNotFound();
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }

            ViewBag.FoodCategoryId = new SelectList(db.FoodCategories, "FoodCategoryId", "Value", food.FoodCategoryId);
            ViewBag.PeopleCategoryId = new SelectList(db.PeopleCategories, "PeopleCategoryId", "Value", food.PeopleCategoryId);
            return View(food);
        }

        // POST: Admin/Canteens/{cid}/Foods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int cid, [Bind(Include = "FoodId,FoodCategoryId,PeopleCategoryId,FoodName,Price,Discount,FoodElement,FoodNutrition,CanteenId,Images")] Food food)
        {
            var canteen = db.Canteens.Find(cid);
            if (canteen == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                food.CanteenId = cid;
                db.Entry(food).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FoodCategoryId = new SelectList(db.FoodCategories, "FoodCategoryId", "Value", food.FoodCategoryId);
            ViewBag.PeopleCategoryId = new SelectList(db.PeopleCategories, "PeopleCategoryId", "Value", food.PeopleCategoryId);
            return View(food);
        }

        // GET: Admin/Canteens/{cid}/Foods/Delete/5
        public ActionResult Delete(int cid, long? id)
        {
            if (db.Canteens.Find(cid) == null)
            {
                return HttpNotFound();
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        // POST: Admin/Canteens/{cid}/Foods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int cid, long id)
        {
            if (db.Canteens.Find(cid) == null)
            {
                return HttpNotFound();
            }
            Food food = db.Foods.Find(id);
            db.Foods.Remove(food);
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
