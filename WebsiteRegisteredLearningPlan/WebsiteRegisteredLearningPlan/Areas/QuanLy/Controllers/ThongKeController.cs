using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.QuanLy.Controllers
{
    public class ThongKeController : Controller
    {
        private Entities db = new Entities();

        // GET: QuanLy/ThongKe
        public ActionResult Index()
        {
            var kETQUADANGKies = db.KETQUADANGKies.Include(k => k.AspNetUser).Include(k => k.CTDT);
            return View(kETQUADANGKies.ToList());
        }

        public void XuatExcel()
        {

            var list = db.KETQUADANGKies.Include(k => k.AspNetUser).Include(k => k.CTDT).ToList();
            ExcelPackage ep = new ExcelPackage();
            ExcelWorksheet Sheet = ep.Workbook.Worksheets.Add("ThongKe");
            Sheet.Cells["A1"].Value = "Email";
            Sheet.Cells["B1"].Value = "Tên học phần";
            Sheet.Cells["C1"].Value = "Ngày đăng ký";
            int row = 2;// dòng bắt đầu ghi dữ liệu
            foreach (var item in list)
            {
                Sheet.Cells[string.Format("A{0}", row)].Value = item.AspNetUser.UserName;
                Sheet.Cells[string.Format("B{0}", row)].Value = item.CTDT.tenhp;
                Sheet.Cells[string.Format("C{0}", row)].Value = item.ngaydk.ToString();
                row++;
            }
            Sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment; filename=" + "ThongKe.xlsx");
            Response.BinaryWrite(ep.GetAsByteArray());
            Response.End();
        }
        [HttpPost]
        public JsonResult ChartData()
        {
            var noidung = db.KETQUADANGKies.GroupBy(item => item.CTDT.tenhp)
                .Select(item2 => new { name = item2.Key, count = item2.Count() }).ToList();
            return Json(new { dbchart = noidung }, JsonRequestBehavior.AllowGet);
        }
    }
}
