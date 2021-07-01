using Microsoft.AspNet.Identity;
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
        private Entities db = new Entities();

        // GET: SinhVien/Hckhht
        public ActionResult DangKyKHHT()
        {
            var ngayHienTai = DateTime.Now;
            var hocKyHienTai = db.HOCKies.ToList().First(item => check(item.ngaykt.Value, item.ngaybd.Value)).mahk;
            var userId = User.Identity.GetUserId();
            if (db.KETQUADANGKies.Any(kqdk => kqdk.email == userId))
                ViewBag.isRegistered = true;
            var chuongTrinhDaoTao = db.CTDTs.Where(item => item.hocky == hocKyHienTai).ToList();
            ViewBag.hocKyHienTai = hocKyHienTai;
            return View(chuongTrinhDaoTao);

        }

        private bool check(DateTime ngaykt, DateTime ngaybd)
        {
            return ngaykt - ngaybd >= DateTime.Now - ngaybd;
        }

        [HttpPost]
        public ActionResult DangKyKHHT(DangKyHP[] model)
        {
            List<DangKyHP> danhSachHPDaChon = model.Where(item => item.isChosen).ToList();
            int tongSoTinChi = danhSachHPDaChon.Sum(item => item.soTinChi);
            if (tongSoTinChi > 16)
            {
                TempData["Success"] = "Số tín chỉ không được trên 16 tín chỉ"; ;
                return DangKyKHHT();
            }
            else if (tongSoTinChi < 12)
            {
                TempData["Success"] = "Số tín chỉ không được dưới 12 tín chỉ"; ;
                return DangKyKHHT();
            }
            var userID = User.Identity.GetUserId();
            danhSachHPDaChon.ForEach(hocPhan =>
            {
                db.KETQUADANGKies.Add(new KETQUADANGKY
                {
                    email = userID,
                    mahp = hocPhan.id,
                    ngaydk = DateTime.Now
                });
            });
            db.SaveChanges();
            TempData["Success"] = "Bạn đã hiệu chỉnh thành công kế hoạch học tập";
            return DangKyKHHT();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public class DangKyHP
    {
        public int id { get; set; }
        public int soTinChi { get; set; }
        public bool isChosen { get; set; }
    }
}