using System.Web.Mvc;

namespace WebsiteRegisteredLearningPlan.Areas.QuanLy
{
    public class QuanLyAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "QuanLy";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "QuanLy_default",
                "QuanLy/{controller}/{action}/{id}",
                new { action = "TrangChu", id = UrlParameter.Optional },
                namespaces: new[] { "WebsiteRegisteredLearningPlan.Areas.QuanLy.Controllers" }
            );
        }
    }
}