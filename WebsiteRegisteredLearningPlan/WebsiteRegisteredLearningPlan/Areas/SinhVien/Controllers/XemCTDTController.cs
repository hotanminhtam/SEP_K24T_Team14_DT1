using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.SinhVien.Controllers
{
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
    }
}