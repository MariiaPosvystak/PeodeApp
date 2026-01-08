using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PeadeApp_.Startup))]
namespace PeadeApp_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
