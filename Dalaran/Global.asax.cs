using Autofac;
using Dalaran.Infrastructure;
using log4net;
using System;
using System.Reflection;
using System.Web;

namespace Dalaran
{
    public class MvcApplication : HttpApplication
    {
        private readonly ILog log = LogManager.GetLogger( MethodBase.GetCurrentMethod().DeclaringType );

        protected void Application_Start()
        {
            var bootstrapper = new DalaranBootstrapper(new ContainerBuilder());
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
            var message = String.Format("[{0}@{1}] {2}\n{3}",
                "Application_Error",
                "Global.asax.cs",
                ex.Message,
                ex.StackTrace
                );

            log.Fatal(message);
        }
    }
}
