using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TranslationSystem.Web.Startup))]

namespace TranslationSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
