using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteRegisteredLearningPlan.Areas.Admin.Controllers
{
    public class homepageController : Controller
    {
        // GET: Admin/homepage
        public ActionResult Index()
        {
            return View();
        }
    }
}