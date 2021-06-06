using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteRegisteredLearningPlan.Areas.QuanLy.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: QuanLy/Home
        public ActionResult TrangChu()
        {
            return View();
        }
    }
}