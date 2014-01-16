using Microsoft.Owin;
using Owin;
using log4net;

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
