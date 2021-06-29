using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.SinhVien.Controllers
{
    public class CapNhatTTController : Controller
    {
        private Entities db = new Entities();
        // GET: SinhVien/CapNhatTT
        public ActionResult CapNhatTT()
        {
            var capnhat = db.CTTAIKHOANs.ToList();
            return View(capnhat);
        }

        // GET: SinhVien/CapNhatTT/CapNhatTT/5
        public ActionResult Edit(string id)
        {
            var users = db.CTTAIKHOANs.Find(id) ?? new CTTAIKHOAN
            {
                id = id,
                hovaten = "",
                sdt = "",
                AspNetUser = db.AspNetUsers.Find(id)
            };
            return View(users);
        }

        // POST: SinhVien/CapNhatTT/CapNhatTT/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, string hovaten, string sdt)
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
            return View("CapNhatTT", user);
        }
    }
}