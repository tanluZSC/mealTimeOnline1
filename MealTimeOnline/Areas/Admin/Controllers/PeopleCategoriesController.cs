using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MealTimeOnline.DataAccessLayer;
using MealTimeOnline.Models.Common;

namespace MealTimeOnline.Areas.Admin.Controllers
{
    public class PeopleCategoriesController : Controller
    {
        private MtoDataContext db = new MtoDataContext();

        // GET: Admin/PeopleCategories
        public ActionResult Index()
        {
            return View(db.PeopleCategories.ToList());
        }

        // GET: Admin/PeopleCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeopleCategory peopleCategory = db.PeopleCategories.Find(id);
            if (peopleCategory == null)
            {
                return HttpNotFound();
            }
            return View(peopleCategory);
        }

        // GET: Admin/PeopleCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PeopleCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PeopleCategoryId,Value")] PeopleCategory peopleCategory)
        {
            if (ModelState.IsValid)
            {
                db.PeopleCategories.Add(peopleCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(peopleCategory);
        }

        // GET: Admin/PeopleCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeopleCategory peopleCategory = db.PeopleCategories.Find(id);
            if (peopleCategory == null)
            {
                return HttpNotFound();
            }
            return View(peopleCategory);
        }

        // POST: Admin/PeopleCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PeopleCategoryId,Value")] PeopleCategory peopleCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(peopleCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(peopleCategory);
        }

        // GET: Admin/PeopleCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeopleCategory peopleCategory = db.PeopleCategories.Find(id);
            if (peopleCategory == null)
            {
                return HttpNotFound();
            }
            return View(peopleCategory);
        }

        // POST: Admin/PeopleCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PeopleCategory peopleCategory = db.PeopleCategories.Find(id);
            db.PeopleCategories.Remove(peopleCategory);
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
