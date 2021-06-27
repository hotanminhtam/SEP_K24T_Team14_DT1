﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.SinhVien.Controllers
{
    [Authorize]
    public class KETQUADANGKiesController : Controller
    {
        private Entities db = new Entities();

        // GET: SinhVien/KETQUADANGKies
        public ActionResult Index()
        {
            var email = User.Identity.Name;
            var userID = db.AspNetUsers.Single(m => m.Email == email).Id;
            var kETQUADANGKies = db.KETQUADANGKies.Where(k => k.AspNetUser.Id == userID).Include(k => k.CTDT);
            return View(kETQUADANGKies.ToList());
        }

        // GET: SinhVien/KETQUADANGKies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KETQUADANGKY kETQUADANGKY = db.KETQUADANGKies.Find(id);
            if (kETQUADANGKY == null)
            {
                return HttpNotFound();
            }
            return View(kETQUADANGKY);
        }

        // GET: SinhVien/KETQUADANGKies/Create
        public ActionResult Create()
        {
            ViewBag.email = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.mahp = new SelectList(db.CTDTs, "id", "tenhp");
            return View();
        }

        // POST: SinhVien/KETQUADANGKies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "email,mahp,ngaydk,id")] KETQUADANGKY kETQUADANGKY)
        {
            if (ModelState.IsValid)
            {
                db.KETQUADANGKies.Add(kETQUADANGKY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.email = new SelectList(db.AspNetUsers, "Id", "Email", kETQUADANGKY.email);
            ViewBag.mahp = new SelectList(db.CTDTs, "id", "tenhp", kETQUADANGKY.mahp);
            return View(kETQUADANGKY);
        }

        // GET: SinhVien/KETQUADANGKies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KETQUADANGKY kETQUADANGKY = db.KETQUADANGKies.Find(id);
            if (kETQUADANGKY == null)
            {
                return HttpNotFound();
            }
            ViewBag.email = new SelectList(db.AspNetUsers, "Id", "Email", kETQUADANGKY.email);
            ViewBag.mahp = new SelectList(db.CTDTs, "id", "tenhp", kETQUADANGKY.mahp);
            return View(kETQUADANGKY);
        }

        // POST: SinhVien/KETQUADANGKies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "email,mahp,ngaydk,id")] KETQUADANGKY kETQUADANGKY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kETQUADANGKY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.email = new SelectList(db.AspNetUsers, "Id", "Email", kETQUADANGKY.email);
            ViewBag.mahp = new SelectList(db.CTDTs, "id", "tenhp", kETQUADANGKY.mahp);
            return View(kETQUADANGKY);
        }

        // GET: SinhVien/KETQUADANGKies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KETQUADANGKY kETQUADANGKY = db.KETQUADANGKies.Find(id);
            if (kETQUADANGKY == null)
            {
                return HttpNotFound();
            }
            return View(kETQUADANGKY);
        }

        // POST: SinhVien/KETQUADANGKies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KETQUADANGKY kETQUADANGKY = db.KETQUADANGKies.Find(id);
            db.KETQUADANGKies.Remove(kETQUADANGKY);
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
