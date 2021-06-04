using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteRegisteredLearningPlan.Areas.Student.Controllers
{
    public class homePageController : Controller
    {
        // GET: Student/homePage
        public ActionResult Index()
        {
            return View();
        }
    }
}