using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.SinhVien.Controllers
{
    public class LichSuController : Controller
    {
        Entities db = new Entities();
        // GET: SinhVien/LichSu
        public ActionResult LichSu(int hk = 1)
        {
            var userId = User.Identity.GetUserId();
            var lichSu = db.KETQUADANGKies.Where(item => item.CTDT.hocky == hk && item.email == userId).ToList();
            return View(lichSu);
        }
    }
}