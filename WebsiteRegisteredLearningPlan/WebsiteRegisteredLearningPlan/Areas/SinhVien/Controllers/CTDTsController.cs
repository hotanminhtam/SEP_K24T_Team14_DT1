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
        public ActionResult XemCTDT()
        {
            var cTDTs = db.CTDTs.ToList();
            return View(cTDTs);
        }  
    }
}
