using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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

        [HttpPost]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("TrangChu", "Home");
        }
    }
}