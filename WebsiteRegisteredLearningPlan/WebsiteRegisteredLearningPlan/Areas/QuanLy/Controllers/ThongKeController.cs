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
        // GET: QuanLy/ThongKe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KETQUADANGKY kETQUADANGKY = db.KETQUADANGKies.Find(id);
            if (kETQUADANGKY == null)
            {
                return HttpNotFound();
            }
            return View(kETQUADANGKY);
        }

        // GET: QuanLy/ThongKe/Create
        public ActionResult Create()
        {
            ViewBag.email = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.mahp = new SelectList(db.CTDTs, "id", "tenhp");
            return View();
        }

        // POST: QuanLy/ThongKe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "email,mahp,ngaydk,id")] KETQUADANGKY kETQUADANGKY)
        {
            if (ModelState.IsValid)
            {
                db.KETQUADANGKies.Add(kETQUADANGKY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.email = new SelectList(db.AspNetUsers, "Id", "Email", kETQUADANGKY.email);
            ViewBag.mahp = new SelectList(db.CTDTs, "id", "tenhp", kETQUADANGKY.mahp);
            return View(kETQUADANGKY);
        }

        // GET: QuanLy/ThongKe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KETQUADANGKY kETQUADANGKY = db.KETQUADANGKies.Find(id);
            if (kETQUADANGKY == null)
            {
                return HttpNotFound();
            }
            ViewBag.email = new SelectList(db.AspNetUsers, "Id", "Email", kETQUADANGKY.email);
            ViewBag.mahp = new SelectList(db.CTDTs, "id", "tenhp", kETQUADANGKY.mahp);
            return View(kETQUADANGKY);
        }

        // POST: QuanLy/ThongKe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "email,mahp,ngaydk,id")] KETQUADANGKY kETQUADANGKY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kETQUADANGKY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.email = new SelectList(db.AspNetUsers, "Id", "Email", kETQUADANGKY.email);
            ViewBag.mahp = new SelectList(db.CTDTs, "id", "tenhp", kETQUADANGKY.mahp);
            return View(kETQUADANGKY);
        }

        // GET: QuanLy/ThongKe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KETQUADANGKY kETQUADANGKY = db.KETQUADANGKies.Find(id);
            if (kETQUADANGKY == null)
            {
                return HttpNotFound();
            }
            return View(kETQUADANGKY);
        }

        // POST: QuanLy/ThongKe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KETQUADANGKY kETQUADANGKY = db.KETQUADANGKies.Find(id);
            db.KETQUADANGKies.Remove(kETQUADANGKY);
            db.SaveChanges();
            return RedirectToAction("Index");
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
}
