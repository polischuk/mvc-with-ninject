using Microsoft.Owin;
using MWN.Web;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace MWN.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
