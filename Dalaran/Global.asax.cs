using Autofac;
using Dalaran.Infrastructure;

namespace Dalaran
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DalaranBootstrapper bootstrapper = new DalaranBootstrapper(new ContainerBuilder());
            bootstrapper.Run();
        }
    }
}
