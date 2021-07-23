using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.SinhVien.Models
{
    public class KetQuaDangKyViewModel
    {
        public CTDT ctdt { get; set; }
        public bool chosen { get; set; }
    }
}