using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.QuanLy.Controllers
{
    [Authorize(Roles = "BCN Khoa, Quản trị")]
    public class HocKyQLController : Controller
    {
        Entities db = new Entities();
        // GET: QuanLy/HocKyQL
        public ActionResult HocKyQL()
        {
            var hocKy = db.HOCKies.ToList();
            return View(hocKy);
        }
        public ActionResult DeadlineHK(int? id)
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
        public ActionResult DeadLineHK([Bind(Include = "tenhk,mahk,ngaybd,ngaykt")] HOCKY hOCKY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOCKY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("HockyQL");
            }
            return View(hOCKY);
        }
    }
}