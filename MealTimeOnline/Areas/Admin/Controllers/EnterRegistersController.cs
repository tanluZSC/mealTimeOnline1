using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MealTimeOnline.DataAccessLayer;
using MealTimeOnline.Models.Dealer;

namespace MealTimeOnline.Areas.Admin.Controllers
{
    public class EnterRegistersController : Controller
    {
        private MtoDataContext db = new MtoDataContext();

        // GET: Admin/EnterRegisters
        public ActionResult Index()
        {
            var enterRegisters = db.EnterRegisters.Include(e => e.User);
            return View(enterRegisters.ToList());
        }

        // GET: Admin/EnterRegisters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnterRegister enterRegister = db.EnterRegisters.Find(id);
            if (enterRegister == null)
            {
                return HttpNotFound();
            }
            return View(enterRegister);
        }

        // GET: Admin/EnterRegisters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnterRegister enterRegister = db.EnterRegisters.Find(id);
            if (enterRegister == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", enterRegister.UserId);
            return View(enterRegister);
        }

        // POST: Admin/EnterRegisters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,RegisterDate,Context,State")] EnterRegister enterRegister)
        {
            var tmp = db.EnterRegisters.Find(enterRegister.Id);
            if (tmp == null)
            {
                return HttpNotFound();
            }
            tmp.State = enterRegister.State;

            if (ModelState.IsValidField("State"))
            {
                db.Entry(tmp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", enterRegister.UserId);
            return View(enterRegister);
        }

        // GET: Admin/EnterRegisters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnterRegister enterRegister = db.EnterRegisters.Find(id);
            if (enterRegister == null)
            {
                return HttpNotFound();
            }
            return View(enterRegister);
        }

        // POST: Admin/EnterRegisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnterRegister enterRegister = db.EnterRegisters.Find(id);
            db.EnterRegisters.Remove(enterRegister);
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
