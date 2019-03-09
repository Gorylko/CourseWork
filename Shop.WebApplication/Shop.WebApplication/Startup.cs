using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shop.WebApplication.Startup))]
namespace Shop.WebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
