using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Areas.SinhVien.Models;
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
            var kETQUADANGKies = db.KETQUADANGKies.Where(k => k.AspNetUser.Id == userID);
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

        public ActionResult chitietlichsu()
        {
            var email = User.Identity.Name;
            var userID = db.AspNetUsers.Single(m => m.Email == email).Id;
            var kETQUADANGKies = db.KETQUADANGKies.Where(k => k.AspNetUser.Id == userID);
            return View(kETQUADANGKies.ToList());
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
        private bool check(DateTime tgdk, DateTime ngaydk)
        {
            return ngaydk == tgdk;
        }
    }
}
