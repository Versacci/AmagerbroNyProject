using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NyAmagerbroProj.Startup))]
namespace NyAmagerbroProj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
