using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dalaran.Startup))]
namespace Dalaran
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
