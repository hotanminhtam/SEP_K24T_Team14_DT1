using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteRegisteredLearningPlan.Areas.SinhVien.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: SinhVien/Home
        public ActionResult TrangChu()
        {
            return View();
        }
    }
}