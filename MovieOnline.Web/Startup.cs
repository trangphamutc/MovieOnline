using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieOnline.Web.Startup))]
namespace MovieOnline.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
