using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.QuanLy.Controllers
{
    [Authorize(Roles = "BCN Khoa, Quản trị")]
    public class PhanQuyenController : Controller
    {
        Entities db = new Entities();
        // GET: QuanLy/PhanQuyen
        public ActionResult PhanQuyen(string username)
        {
            var user = db.AspNetUsers.SingleOrDefault(item => item.Email == username);
            if (user == null)
            {
                return new HttpStatusCodeResult(404);
            }
            ViewBag.user = username;
            ViewBag.role = user.AspNetRoles.ToList()[0].Id;
            var phanQuyen = db.AspNetRoles.ToList();
            return View(phanQuyen);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PhanQuyen(string username, string role)
        {
            var user = db.AspNetUsers.SingleOrDefault(item => item.Email == username);
            if (user == null)
            {
                return new HttpStatusCodeResult(404);
            }
            var roleObj = user.AspNetRoles.ToList()[0];
            user.AspNetRoles.Remove(roleObj);
            user.AspNetRoles.Add(db.AspNetRoles.Find(role));
            db.SaveChanges();
            return Redirect("~/QuanLy/DSTaiKhoan/DSTaiKhoan");
        }
    }
}