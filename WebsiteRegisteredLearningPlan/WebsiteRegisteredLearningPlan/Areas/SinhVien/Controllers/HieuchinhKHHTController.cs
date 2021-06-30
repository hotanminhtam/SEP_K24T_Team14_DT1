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
        public ActionResult HieuchinhKHHT()
        {
            var ngayHienTai = DateTime.Now;
            var hocKyHienTai = db.HOCKies.ToList().First(item => check(item.ngaykt.Value, item.ngaybd.Value)).mahk;
            var userId = User.Identity.GetUserId();
            var nhungMonTrongHocKy = db.CTDTs.Where(ctdt => ctdt.hocky == hocKyHienTai)
                .Select(item => new KetQuaDangKyViewModel { ctdt = item, chosen = item.KETQUADANGKies.FirstOrDefault(kqdk => kqdk.email == userId) != null}).ToList();
            return View(nhungMonTrongHocKy);
        }

        [HttpPost]
        public ActionResult HieuchinhKHHT(DangKyHP[] model)
        {
            List<DangKyHP> danhSachHPDaChon = model.Where(item => item.isChosen).ToList();
            int tongSoTinChi = danhSachHPDaChon.Sum(item => item.soTinChi);
            if (tongSoTinChi > 16 || tongSoTinChi < 12)
            {
                ViewBag.error = "Số tín chỉ không được dưới 12 và lớn hơn 16 tín chỉ";
                return HieuchinhKHHT();
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
                        ngaydk = DateTime.Now
                    });
                else if (dangKyTruocDay != null && !item.isChosen)
                    db.KETQUADANGKies.Remove(dangKyTruocDay);
            });
            db.SaveChanges();
            ViewBag.success = "Bạn đã hiệu chỉnh thành công kế hoạch học tập";
            return HieuchinhKHHT();
        }

        private bool check(DateTime ngayKt, DateTime ngayBd)
        {
            return ngayKt - ngayBd >= DateTime.Now - ngayBd;
        }
    }
}