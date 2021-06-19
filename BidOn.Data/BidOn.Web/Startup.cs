using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BidOn.Web.Startup))]
namespace BidOn.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
