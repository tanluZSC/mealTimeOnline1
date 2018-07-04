using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MealTimeOnline.DataAccessLayer;
using MealTimeOnline.Models.Consumer;

namespace MealTimeOnline.Areas.Admin.Controllers
{
    public class RedPacketsController : Controller
    {
        private MtoDataContext db = new MtoDataContext();

        // GET: Admin/RedPackets
        public ActionResult Index()
        {
            var redPackets = db.RedPackets.Include(r => r.User);
            return View(redPackets.ToList());
        }

        // GET: Admin/RedPackets/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RedPacket redPacket = db.RedPackets.Find(id);
            if (redPacket == null)
            {
                return HttpNotFound();
            }
            return View(redPacket);
        }

        // GET: Admin/RedPackets/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username");
            return View();
        }

        // POST: Admin/RedPackets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RedPacketId,Deadline,Money,UserId")] RedPacket redPacket)
        {
            if (ModelState.IsValid)
            {
                db.RedPackets.Add(redPacket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", redPacket.UserId);
            return View(redPacket);
        }

        // GET: Admin/RedPackets/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RedPacket redPacket = db.RedPackets.Find(id);
            if (redPacket == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", redPacket.UserId);
            return View(redPacket);
        }

        // POST: Admin/RedPackets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RedPacketId,Deadline,Money,UserId")] RedPacket redPacket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(redPacket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", redPacket.UserId);
            return View(redPacket);
        }

        // GET: Admin/RedPackets/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RedPacket redPacket = db.RedPackets.Find(id);
            if (redPacket == null)
            {
                return HttpNotFound();
            }
            return View(redPacket);
        }

        // POST: Admin/RedPackets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            RedPacket redPacket = db.RedPackets.Find(id);
            db.RedPackets.Remove(redPacket);
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
