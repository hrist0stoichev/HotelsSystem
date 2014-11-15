using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotelsSystem.Web.Startup))]

namespace HotelsSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
