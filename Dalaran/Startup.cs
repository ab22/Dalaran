using Microsoft.Owin;
using Owin;
using log4net;

[assembly: OwinStartupAttribute(typeof(Dalaran.Startup))]
namespace Dalaran
{
    public partial class Startup
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Startup));
        
        public void Configuration(IAppBuilder app)
        {
            //log4net.Config.BasicConfigurator.Configure();

            log.Debug("This is a debug message");
            log.Warn("This is a warn message");
            log.Error("This is a error message");
            log.Fatal("This is a fatal message");

            ConfigureAuth(app);
        }
    }
}
