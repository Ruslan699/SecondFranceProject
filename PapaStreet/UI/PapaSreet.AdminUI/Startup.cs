using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PapaSreet.AdminUI.Startup))]
namespace PapaSreet.AdminUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
