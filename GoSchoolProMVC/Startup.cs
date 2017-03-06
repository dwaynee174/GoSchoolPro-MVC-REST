using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoSchoolProMVC.Startup))]
namespace GoSchoolProMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
