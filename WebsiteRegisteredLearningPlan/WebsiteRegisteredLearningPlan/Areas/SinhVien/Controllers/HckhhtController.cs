using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.SinhVien.Controllers
{
    public class HckhhtController : Controller
    {
        private Entities db = new Entities();

        // GET: SinhVien/Hckhht
        public ActionResult Hckhht()
        {
            var ngayHienTai = DateTime.Now;
            var hocKyHienTai = db.HOCKies.ToList().First(item => check(item.ngaykt.Value, item.ngaybd.Value)).mahk;
            //var cTDTs = db.CTDTs.Include(c => c.HOCKY1);
            var cTDTs = db.CTDTs.Where(item => item.hocky == hocKyHienTai).ToList();
            ViewBag.hocKyHienTai = hocKyHienTai;
            return View(cTDTs);
        }

        private bool check(DateTime ngaykt, DateTime ngaybd)
        {
            return ngaykt - ngaybd >= DateTime.Now - ngaybd;
        }

        [HttpPost]
        public ActionResult Hckhht(DangKyHP[] model)
        {
            List<DangKyHP> danhSachHPDaChon = model.Where(item => item.isChosen).ToList();
            int tongSoTinChi = danhSachHPDaChon.Sum(item => item.soTinChi);
            if (tongSoTinChi > 16)
            {
                TempData["Success"] = "Số tín chỉ không được trên 16 tín chỉ"; ;
                return Hckhht();
            }
            else if (tongSoTinChi < 12)
            {
                TempData["Success"] = "Số tín chỉ không được dưới 12 tín chỉ"; ;
                return Hckhht();
            }
            var email = User.Identity.Name;
            //var userID = db.AspNetUsers.Single(item => item.Email == email).Id;
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
            TempData["Success"] = "Bạn đã hiệu chỉnh thành công kế hoạch học tập";
            return Hckhht();
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