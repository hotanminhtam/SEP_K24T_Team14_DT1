using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.QuanLy.Controllers
{
    [Authorize]
    public class DSTaiKhoanController : Controller
    {
        Entities db = new Entities();
        // GET: QuanLy/DSTaiKhoan
        public ActionResult DSTaiKhoan()
        {
            var danhSach = db.AspNetUsers.ToList();
            return View(danhSach);
        }
    }
}