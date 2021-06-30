using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.QuanLy.Controllers
{
    public class QLyTaiKhoanController : Controller
    {
        Entities db = new Entities();
        // GET: QuanLy/QLyTaiKhoan
        public ActionResult QLyTaiKhoan()
        {
            var taikhoan = db.AspNetUsers.ToList();
            return View(taikhoan);
        }
    }
}