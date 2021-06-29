﻿using System;
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
    }
}