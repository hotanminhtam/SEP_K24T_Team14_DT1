using System;
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
    public class CTDTsController : Controller
    {
        private Entities db = new Entities();

        // GET: SinhVien/CTDTs
        public ActionResult Index()
        {
            var cTDTs = db.CTDTs.Include(c => c.HOCKY1);
            return View(cTDTs.ToList());
        }

        // GET: SinhVien/CTDTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTDT cTDT = db.CTDTs.Find(id);
            if (cTDT == null)
            {
                return HttpNotFound();
            }
            return View(cTDT);
        }

        // GET: SinhVien/CTDTs/Create
        public ActionResult Create()
        {
            ViewBag.hocky = new SelectList(db.HOCKies, "mahk", "tenhk");
            return View();
        }

        // POST: SinhVien/CTDTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tenhp,mahp,tinchi,hocky")] CTDT cTDT)
        {
            if (ModelState.IsValid)
            {
                db.CTDTs.Add(cTDT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.hocky = new SelectList(db.HOCKies, "mahk", "tenhk", cTDT.hocky);
            return View(cTDT);
        }

        // GET: SinhVien/CTDTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTDT cTDT = db.CTDTs.Find(id);
            if (cTDT == null)
            {
                return HttpNotFound();
            }
            ViewBag.hocky = new SelectList(db.HOCKies, "mahk", "tenhk", cTDT.hocky);
            return View(cTDT);
        }

        // POST: SinhVien/CTDTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tenhp,mahp,tinchi,hocky")] CTDT cTDT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTDT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.hocky = new SelectList(db.HOCKies, "mahk", "tenhk", cTDT.hocky);
            return View(cTDT);
        }

        // GET: SinhVien/CTDTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTDT cTDT = db.CTDTs.Find(id);
            if (cTDT == null)
            {
                return HttpNotFound();
            }
            return View(cTDT);
        }

        // POST: SinhVien/CTDTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CTDT cTDT = db.CTDTs.Find(id);
            db.CTDTs.Remove(cTDT);
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
