using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebsiteRegisteredLearningPlan.Startup))]
namespace WebsiteRegisteredLearningPlan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
