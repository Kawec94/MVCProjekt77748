using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCProjekt77748.Startup))]
namespace MVCProjekt77748
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
