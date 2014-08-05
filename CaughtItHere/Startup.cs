using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CaughtItHere.Startup))]
namespace CaughtItHere
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
