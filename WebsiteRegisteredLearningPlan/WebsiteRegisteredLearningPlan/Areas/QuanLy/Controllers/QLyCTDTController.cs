using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.QuanLy.Controllers
{
    [Authorize]
    public class QLyCTDTController : Controller
    {
        Entities db = new Entities();
        // GET: QuanLy/QLyCTDT
        public ActionResult ChuongTrinhDaoTao()
        {
            var ctdt = db.CTDTs.ToList(); 
            return View(ctdt);
        }
    }
}