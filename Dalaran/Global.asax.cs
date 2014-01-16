using Autofac;
using Dalaran.Infrastructure;
using log4net;
using System;
using System.Reflection;
using System.Web;

namespace Dalaran
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly ILog log = LogManager.GetLogger( MethodBase.GetCurrentMethod().DeclaringType );

        protected void Application_Start()
        {
            DalaranBootstrapper bootstrapper = new DalaranBootstrapper(new ContainerBuilder());
            bootstrapper.Run();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError().GetBaseException();

            //Do not log 404 exceptions
            if (ex is HttpException)
            {
                if (ex.Message.Contains("The controller for path"))
                {
                    return;
                }
            }

            log.Fatal(ex.Message);
        }
    }
}
