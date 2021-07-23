using System.Linq;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.QuanLy.Controllers
{
    public class ThongKeController : Controller
    {
        Entities db = new Entities();
        // GET: QuanLy/ThongKe
        public ActionResult ThongKe(int hk = 1)
        {
            if (db.HOCKies.Find(hk) == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            ViewBag.hk = hk;
            return View();
        }

        [HttpPost]
        public JsonResult ChartData(int hk = 1)
        {
            if (db.HOCKies.Find(hk) == null)
                return Json(new { dbchart = "[]", code = 404 }, JsonRequestBehavior.AllowGet);
            var noidung = db.CTDTs.Where(item => item.hocky == hk)
                .Select(item => new { name = item.tenhp, count = item.KETQUADANGKies.Count(kqdk => kqdk.active == 1) }).ToList();
            return Json(new { dbchart = noidung, code = 200 }, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult print(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var cus = User.Identity.GetUserId();
        //    var hp = db.KETQUADANGKies.Where(n => n.AspNetUser.Id == cus && n.CTDT.HOCKY1.mahk == id).Select(n => n.AspNetUser.CTTAIKHOAN.id).ToList();
        //    var data = db.CTDTs.Where(n => hp.Contains(n.tenhp)).ToList();
        //    string NameUser = User.Identity.Name;
        //    var hocKy = db.CTDTs.Find(id);

        //    var pck = new ExcelPackage(new FileInfo(Server.MapPath("~/assets/ThongKe.xlsx")));
        //    ExcelWorksheet ws = pck.Workbook.Worksheets[0];
        //    ws.Cells["A7"].Value = NameUser;
        //    ws.Cells["F7"].Value = hocKy.hocky;
        //    int rowStart = 40;
        //    foreach (var item in data)
        //    {
        //        ws.Cells[string.Format("A{0}", rowStart)].Value = "Email";
        //        ws.Cells[string.Format("C{0}", rowStart)].Value = "Học kỳ";
        //        ws.Cells[string.Format("E{0}", rowStart)].Value = "Môn học";
        //        ws.Cells[string.Format("H{0}", rowStart)].Value = "Số lượng";
        //        rowStart++;
        //    }
        //    var filedata = pck.GetAsByteArray();
        //    return File(filedata, "application/octet-stream", "ThongKe.xlsx");
        //}
    }
}