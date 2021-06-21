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
        public ActionResult HocKy()
        {
            var hocKyDuyNhat = db.HOCKies.ToList();
            var chiTietHK = db.CTDTs.ToList();
            return View(hocKyDuyNhat);
        }
        
    }
}