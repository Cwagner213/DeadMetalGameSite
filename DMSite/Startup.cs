using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DMSite.Startup))]
namespace DMSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
