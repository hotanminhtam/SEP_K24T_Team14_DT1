using System.Web.Mvc;

namespace WebsiteRegisteredLearningPlan.Areas.SinhVien
{
    public class SinhVienAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SinhVien";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SinhVien_default",
                "SinhVien/{controller}/{action}/{id}",
                new { action = "TrangChu", id = UrlParameter.Optional },
                namespaces: new[] { "WebsiteRegisteredLearningPlan.Areas.SinhVien.Controllers" }
            );
        }
    }
}