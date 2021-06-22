using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.SinhVien.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        Entities db = new Entities();
        // GET: SinhVien/Home
        public ActionResult TrangChu(int Hk = 1)
        {
            var cTHK = db.CTDTs.Where(ctdt => ctdt.hocky == Hk).ToList();
            return View();
        }
    }
}