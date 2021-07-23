using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.SinhVien.Controllers
{
    [AllowAnonymous]
    public class XemCTDTController : Controller
    {
        Entities db = new Entities();
        // GET: SinhVien/XemCTDT
        public ActionResult ChuongTrinhDaoTao()
        {
            var ctdt = db.CTDTs.ToList();
            return View(ctdt);
        }

        //Search
        public ActionResult Search(string keyword)
        {
            var kw = db.CTDTs.ToList();
            kw = kw.Where(p => p.mahp.ToLower().Contains(keyword.ToLower()) || 
                          p.tenhp.ToLower().Contains(keyword.ToLower())).ToList();
            
            ViewBag.Keyword = keyword;
            return View("ChuongTrinhDaoTao", kw);
        }

        public void ExportToExcel()
        {
            var ctdt = db.CTDTs.ToList();
            ExcelPackage ex = new ExcelPackage();
            ExcelWorksheet sheet = ex.Workbook.Worksheets.Add("ChuongTrinhDaoTao");
            sheet.Cells["A1"].Value = "STT";
            sheet.Cells["B1"].Value = "Mã học phần";
            sheet.Cells["C1"].Value = "Tên học phần";
            sheet.Cells["D1"].Value = "Học kỳ";
            sheet.Cells["E1"].Value = "Tín chỉ";
            int row = 2;
            foreach (var i in ctdt)
            {
                sheet.Cells[string.Format("A{0}", row)].Value = i.id;
                sheet.Cells[string.Format("B{0}", row)].Value = i.mahp;
                sheet.Cells[string.Format("C{0}", row)].Value = i.tenhp;
                sheet.Cells[string.Format("D{0}", row)].Value = i.hocky;
                sheet.Cells[string.Format("E{0}", row)].Value = i.tinchi;
                row++;
            }

            sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disaposition", "attachment; filename=" + "ChuongTrinhDaoTao.xlxs");
            Response.BinaryWrite(ex.GetAsByteArray());
            Response.End();
        }
    }
}