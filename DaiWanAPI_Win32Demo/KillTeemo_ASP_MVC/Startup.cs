using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KillTeemo_ASP_MVC.Startup))]
namespace KillTeemo_ASP_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
