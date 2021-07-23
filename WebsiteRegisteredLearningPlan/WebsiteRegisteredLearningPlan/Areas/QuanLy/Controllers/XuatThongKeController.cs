using OfficeOpenXml;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.QuanLy.Controllers
{
    [Authorize]
    public class XuatThongKeController : Controller
    {
        Entities db = new Entities();
        // GET: QuanLy/XuatThongKe
        public ActionResult print(int? hk)
        {
            if (hk == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var currentRow = 7;

            var cacMonHoc = db.CTDTs.Where(ctdt => ctdt.hocky == hk).ToList();
            var tongSoLuongDangKy = new int[cacMonHoc.Count];

            using (ExcelPackage pck = new ExcelPackage(new FileInfo(Server.MapPath("~/Content/assets/ThongKe.xlsx"))))
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets[0];
                var users = db.AspNetUsers.ToList();
                var tongSoOThem = (cacMonHoc.Count() * users.Count) + users.Count - 1;
                ws.Cells[currentRow, 3, currentRow - 1 + tongSoOThem, 3].Merge = true;
                ws.Cells[currentRow, 3, currentRow + tongSoOThem, 3].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                ws.Cells[currentRow, 3].Value = hk;
                foreach (var user in users)
                {
                    ws.Cells[currentRow, 1, currentRow + cacMonHoc.Count() - 1, 1].Merge = true;
                    ws.Cells[currentRow, 1, currentRow + cacMonHoc.Count() - 1, 1].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    ws.Cells[currentRow, 1].Value = user.Email;
                    for (int i = 0; i < cacMonHoc.Count; i++)
                    {
                        ws.Cells[currentRow + i, 5].Value = cacMonHoc[i].tenhp;
                        var lichSuDangKy = cacMonHoc[i].KETQUADANGKies.Where(kqdk => kqdk.email ==
                                    user.Id && kqdk.active == 1);
                        if (lichSuDangKy.Any())
                        {
                            tongSoLuongDangKy[i] += 1;
                        }
                        ws.Cells[currentRow + i, 8].Value = lichSuDangKy.Any() ? "v" : "x";
                    }
                    currentRow += cacMonHoc.Count() + 1;
                }

                ws = pck.Workbook.Worksheets[1];
                currentRow = 8;
                ws.Cells[currentRow, 1, currentRow + cacMonHoc.Count - 1, 1].Merge = true;
                ws.Cells[currentRow, 1].Value = hk;
                for (int i = 0; i < tongSoLuongDangKy.Length; i++)
                {
                    ws.Cells[currentRow + i, 3].Value = cacMonHoc[i].tenhp;
                    ws.Cells[currentRow + i, 5].Value = tongSoLuongDangKy[i];
                }
                return File(pck.GetAsByteArray(), "application/octet-stream", $"ThongKe-HocKy-{hk}.xlsx");
            }
        }
    }
}