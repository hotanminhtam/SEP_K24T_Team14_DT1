using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.SinhVien.Controllers
{
    [Authorize]
    public class HocKyController : Controller
    {
        Entities db = new Entities();

        // GET: SinhVien/HocKy
        public ActionResult HocKy(int Hk = 1)
        {
            var chiTietHK = db.CTDTs.Where(ctdt => ctdt.hocky == Hk).ToList();
            return View(chiTietHK);
        }
    }
}