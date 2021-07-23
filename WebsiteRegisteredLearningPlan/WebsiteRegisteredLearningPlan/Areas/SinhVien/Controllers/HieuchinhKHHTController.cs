using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Models;
using Microsoft.AspNet.Identity;
using WebsiteRegisteredLearningPlan.Areas.SinhVien.Models;

namespace WebsiteRegisteredLearningPlan.Areas.SinhVien.Controllers
{
    public class HieuchinhKHHTController : Controller
    {
        Entities db = new Entities();
        // GET: SinhVien/HieuchinhKHHT
        [HttpGet]
        public ActionResult HieuchinhKHHT(int? hk = null)
        {
            var ngayHienTai = DateTime.Now;
            var hocKyHienTai = db.HOCKies.ToList().First(item => check(item.ngaykt.Value, item.ngaybd.Value)).mahk;
            hk = hk ?? hocKyHienTai;
            var userId = User.Identity.GetUserId();
            var nhungMonTrongHocKy = db.CTDTs.Where(item => item.hocky == hk || item.KETQUADANGKies
                        .Count(kqdk => kqdk.email == userId) == 0)
                .Where(item => item.hocky <= hk)
                .Select(item => new KetQuaDangKyViewModel { ctdt = item, chosen = item.KETQUADANGKies.FirstOrDefault(kqdk => kqdk.email == userId && kqdk.active == 1) != null }).ToList();
            ViewBag.hocKy = hk;
            return View(nhungMonTrongHocKy);
        }

        [HttpPost]
        public ActionResult HieuchinhKHHT(DangKyHP[] model, int? hk = null)
        {
            List<DangKyHP> danhSachHPDaChon = model.Where(item => item.isChosen).ToList();
            int tongSoTinChi = danhSachHPDaChon.Sum(item => item.soTinChi);
            if (tongSoTinChi > 16 || tongSoTinChi < 12)
            {
                ViewBag.error = "Số tín chỉ không được dưới 12 và lớn hơn 16 tín chỉ";
                return HieuchinhKHHT(hk);
            }
            var userID = User.Identity.GetUserId();
            var ketQuaDks = db.KETQUADANGKies.Where(kq => kq.email == userID).ToList();
            model.ToList().ForEach(item =>
            {
                var dangKyTruocDay = ketQuaDks.FirstOrDefault(kqdk => kqdk.mahp == item.id);
                if (dangKyTruocDay == null && item.isChosen)
                    db.KETQUADANGKies.Add(new KETQUADANGKY
                    {
                        email = userID,
                        mahp = item.id,
                        ngaydk = DateTime.Now,
                        active = 1
                    });
                else if (dangKyTruocDay != null && !item.isChosen)
                {
                    dangKyTruocDay.active = 0;
                    db.KETQUADANGKies.Add(new KETQUADANGKY
                    {
                        email = userID,
                        mahp = item.id,
                        ngaydk = DateTime.Now,
                        active = 0
                    });
                }
            });
            db.SaveChanges();
            ViewBag.success = "Bạn đã hiệu chỉnh thành công kế hoạch học tập";
            return HieuchinhKHHT(hk);
        }

        private bool check(DateTime ngayKt, DateTime ngayBd)
        {
            return ngayKt - ngayBd >= DateTime.Now - ngayBd;
        }
    }
}