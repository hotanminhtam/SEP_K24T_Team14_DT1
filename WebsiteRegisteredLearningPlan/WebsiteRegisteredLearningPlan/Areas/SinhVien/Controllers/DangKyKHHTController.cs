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

        [HttpPost]
        public ActionResult DangKyKHHT(DangKyHP[] model)
        {
            List<DangKyHP> danhSachHPDaChon = model.Where(item => item.isChosen).ToList();
            int tongSoTinChi = danhSachHPDaChon.Sum(item => item.soTinChi);
            if (tongSoTinChi > 16 || tongSoTinChi < 12)
            {
                ViewBag.error = "Số tín chỉ không được dưới 12 và lớn hơn 16 tín chỉ";
                return DangKyKHHT();
            }
            var email = User.Identity.Name;
            var userID = db.AspNetUsers.Single(item => item.Email == email).Id;
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
            ViewBag.success = "Bạn đã đăng ký thành công kế hoạch học tập";
            return DangKyKHHT();
        }

        private bool check(DateTime ngayKt, DateTime ngayBd)
        {
            return ngayKt - ngayBd >= DateTime.Now - ngayBd;
        }
    }

    public class DangKyHP
    {
        public int id { get; set; }
        public int soTinChi { get; set; }
        public bool isChosen { get; set; }
    }
}