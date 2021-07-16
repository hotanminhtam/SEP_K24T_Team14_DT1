using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.QuanLy.Controllers
{
    public class HOCKiesController : Controller
    {
        private Entities db = new Entities();

        public ActionResult Index()
        {
            return View(db.HOCKies.ToList());
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOCKY hOCKY = db.HOCKies.Find(id);
            if (hOCKY == null)
            {
                return HttpNotFound();
            }
            return View(hOCKY);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tenhk,mahk,ngaybd,ngaykt")] HOCKY hOCKY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOCKY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hOCKY);
        }
    }
}
