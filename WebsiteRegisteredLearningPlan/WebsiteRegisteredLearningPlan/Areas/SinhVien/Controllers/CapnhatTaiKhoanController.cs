using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.SinhVien.Controllers
{
    public class CapnhatTaiKhoanController : Controller
    {
        Entities db = new Entities();
        // GET: SinhVien/CapnhatTaiKhoan
        public ActionResult CapNhatTK(string id)
        {
            var user = db.CTTAIKHOANs.Find(id) ?? new CTTAIKHOAN
            {
                id = id,
                hovaten = "",
                sdt = "",
                AspNetUser = db.AspNetUsers.Find(id)
            };
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Luu(string id, string hovaten, string sdt)
        {
            var user = db.CTTAIKHOANs.Find(id);
            if (user == null)
            {
                user = new CTTAIKHOAN
                {
                    id = id,
                    hovaten = hovaten,
                    sdt = sdt
                };
                db.CTTAIKHOANs.Add(user);
            }
            else
            {
                user.hovaten = hovaten;
                user.sdt = sdt;
                db.Entry<CTTAIKHOAN>(user).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            ViewBag.message = "Cập nhật thành công";
            return View("CapnhatTK", user);
        }
    }
}