using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.QuanLy.Controllers
{
    [Authorize]
    public class HocKyQLController : Controller
    {
        Entities db = new Entities();
        // GET: QuanLy/HocKyQL
        public ActionResult HocKyQL()
        {
            var hocKy = db.HOCKies.ToList();
            return View(hocKy);
        }
    }
}