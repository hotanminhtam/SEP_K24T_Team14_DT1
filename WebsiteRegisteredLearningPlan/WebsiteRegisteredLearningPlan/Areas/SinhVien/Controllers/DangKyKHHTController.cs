using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.SinhVien.Controllers
{
    [Authorize]
    public class DangKyKHHTController : Controller
    {
        Entities db = new Entities();
        // GET: SinhVien/DangKyKHHT
        public ActionResult DangKyKHHT()
        {
            // ben nay de kieu gi, ben kia de y nhu v
            // ow day no de List<CTDT>
            var ngayHienTai = DateTime.Now;
            var hocKyHienTai = db.HOCKies.ToList().First(item => check(item.ngaykt.Value, item.ngaybd.Value)).mahk;
            var chuongTrinhDaoTao = db.CTDTs.Where(item => item.hocky == hocKyHienTai).ToList();
            ViewBag.hocKyHienTai = hocKyHienTai;
            return View(chuongTrinhDaoTao);
        }

        private bool check(DateTime ngayKt, DateTime ngayBd)
        {
            return ngayKt - ngayBd >= DateTime.Now - ngayBd;
        }
    }
}