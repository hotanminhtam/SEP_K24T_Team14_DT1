using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.QuanLy.Controllers
{
    [Authorize(Roles = "BCN Khoa, Quản trị")]
    public class CTDTController : Controller
    {
        Entities db = new Entities();
        // GET: QuanLy/CTDT
        public ActionResult CTDT()
        {
            var cTDT = db.CTDTs.ToList();
            return View(cTDT);
        }
    }
}