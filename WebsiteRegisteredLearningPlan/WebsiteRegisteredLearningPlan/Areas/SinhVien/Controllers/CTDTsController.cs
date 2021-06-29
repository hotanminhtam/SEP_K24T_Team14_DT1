using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.SinhVien.Controllers
{
    
    public class CTDTsController : Controller
    {
        private Entities db = new Entities();

        // GET: SinhVien/CTDTs
        public ActionResult Index()
        {
            var cTDTs = db.CTDTs.Include(c => c.HOCKY1);
            return View(cTDTs.ToList());
        }
        public ActionResult Search(string keyword)
        {
            var model = db.CTDTs.ToList();
            model = model.Where(p => p.tenhp.ToLower().Contains(keyword.ToLower())).ToList();
            ViewBag.Keyword = keyword;
            return View("Index", model);
        }
        public ActionResult SearchHP(string keyword)
        {
            var model = db.CTDTs.ToList();
            model = model.Where(p => p.mahp.ToLower().Contains(keyword.ToLower())).ToList();
            ViewBag.Keyword = keyword;
            return View("Index", model);
        }
        public ActionResult SearchHK(string keyword)
        {
            var model = db.CTDTs.ToList();
            model = model.Where(p => p.hocky.ToString().ToLower().Contains(keyword.ToLower())).ToList();
            ViewBag.Keyword = keyword;
            return View("Index", model);
        }
        // GET: SinhVien/CTDTs/Edit/5
    }
}
