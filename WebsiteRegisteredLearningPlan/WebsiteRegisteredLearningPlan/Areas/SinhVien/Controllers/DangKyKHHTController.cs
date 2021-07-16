using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public ActionResult DangKyKHHT(int? Dk = null)
        {
            // ben nay de kieu gi, ben kia de y nhu v
            // ow day no de List<CTDT>
            var ngayHienTai = DateTime.Now;
            HOCKY hocKy = Dk == null ? db.HOCKies.FirstOrDefault(item => ngayHienTai >= item.ngaybd && ngayHienTai <= item.ngaykt) : db.HOCKies.Find(Dk);

            if (Dk != null && hocKy == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            else if ((Dk == null && hocKy == null) || hocKy.ngaybd > ngayHienTai || ngayHienTai > hocKy.ngaykt)
            {
                ViewBag.ErrorMessage = "Chưa đến thời gian đăng ký";
                return View();
            }

            var userId = User.Identity.GetUserId();
            if (db.KETQUADANGKies.Any(kqdk => kqdk.email == userId && kqdk.CTDT.hocky == hocKy.mahk))
                ViewBag.isRegistered = true;

            var chuongTrinhDaoTao = db.CTDTs.Where(item => item.hocky == hocKy.mahk || item.KETQUADANGKies
                        .Count(kqdk => kqdk.email == userId) == 0)
                .Where(item => item.hocky <= hocKy.mahk).ToList();
            ViewBag.hocKyHienTai = hocKy.mahk;
            return View(chuongTrinhDaoTao);
        }

        [HttpPost]
        public ActionResult DangKyKHHT(DangKyHP[] model)
        {
            List<DangKyHP> danhSachHPDaChon = model.Where(item => item.isChosen).ToList();
            int tongSoTinChi = danhSachHPDaChon.Sum(item => item.soTinChi);
            if (model.Count(item => item.isChosen) < model.Length && (tongSoTinChi > 16 || tongSoTinChi < 12))
            {
                ViewBag.error = "Số tín chỉ không được dưới 12 và lớn hơn 16 tín chỉ";
                return DangKyKHHT();
            }
            var userID = User.Identity.GetUserId();
            danhSachHPDaChon.ForEach(hocPhan =>
            {
                db.KETQUADANGKies.Add(new KETQUADANGKY
                {
                    email = userID,
                    mahp = hocPhan.id,
                    ngaydk = DateTime.Now,
                    active = 1
                });
            });
            db.SaveChanges();
            ViewBag.success = "Bạn đã đăng ký thành công kế hoạch học tập";
            return DangKyKHHT();
        }
    }

    public class DangKyHP
    {
        public int id { get; set; }
        public int soTinChi { get; set; }
        public bool isChosen { get; set; }
    }
}