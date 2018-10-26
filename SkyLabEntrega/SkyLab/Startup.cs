using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SkyLab.Startup))]
namespace SkyLab
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
