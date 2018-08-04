using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibrApp2.Startup))]
namespace LibrApp2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
