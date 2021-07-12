using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.QuanLy.Controllers
{
    public class ThongKeController : Controller
    {
        Entities db = new Entities();
        // GET: QuanLy/ThongKe
        public ActionResult ThongKe()
        {

            //    var thongKe = db.KETQUADANGKies.Include("mahp").ToList();
            //    var noidung = db.KETQUADANGKies.Include("mahp").GroupBy(item => item.CTDT.tenhp).Select(item2 => new { name = item2.Key, count = item2.SingleOrDefault().mahp });
            //    return Json(noidung, JsonRequestBehavior.AllowGet);
            //}
            return View();
        }
    }
}