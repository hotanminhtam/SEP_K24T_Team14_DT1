using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.QuanLy.Controllers
{
    public class CapNhatTGController : Controller
    {
        Entities db = new Entities();
        // GET: QuanLy/CapNhatTG
        public ActionResult CapNhatTG()
        {
            var ctdt = db.CTDTs.ToList();
            return View(ctdt);
        }
    }
}