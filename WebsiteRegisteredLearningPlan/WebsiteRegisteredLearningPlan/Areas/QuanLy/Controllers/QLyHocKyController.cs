using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.QuanLy.Controllers
{
    [Authorize]
    public class QLyHocKyController : Controller
    {
        Entities db = new Entities();
        // GET: QuanLy/QLyHocKy
        public ActionResult QLyHocKy(int hk = 1)
        {
            var ctdt = db.CTDTs.Where(ct => ct.hocky == hk).ToList();
            return View(ctdt);
        }
    }
}