using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SessionManagement.Startup))]
namespace SessionManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
