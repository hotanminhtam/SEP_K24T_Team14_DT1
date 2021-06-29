using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.SinhVien.Controllers
{
    public class HocKyController : Controller
    {
        Entities db = new Entities();
        // GET: SinhVien/HocKy
        public ActionResult HocKy(int hk = 1 )
        {
            var hocky = db.CTDTs.Where(ctdt => ctdt.hocky == hk).ToList();
            return View(hocky);
        }
    }
}