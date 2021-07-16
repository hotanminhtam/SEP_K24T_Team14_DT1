using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteRegisteredLearningPlan.Areas.QuanLy.Controllers
{
    [Authorize(Roles = "BCN Khoa, Quản trị")]
    public class HomeController : Controller
    {
        // GET: QuanLy/Home
        public ActionResult TrangChu()
        {
            return View();
        }
    }
}