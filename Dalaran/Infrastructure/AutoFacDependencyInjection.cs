using Autofac;
using Autofac.Integration.Mvc;
using Dalaran.DAL;
using Dalaran.DAL.Interfaces;
using Dalaran.DAL.Repositories;
using Dalaran.Infrastructure.Interfaces;
using System.Data.Entity;
using System.Web.Mvc;

namespace Dalaran.Infrastructure
{
    public class AutoFacDependencyInjection : IGlobalConfiguration
    {
        readonly ContainerBuilder builder;

        public AutoFacDependencyInjection(ContainerBuilder builder)
        {
            this.builder = builder;
        }

        public void Configure()
        {
            builder.RegisterControllers( typeof(MvcApplication).Assembly );

            RegisterServices();
            var container = builder.Build();
            DependencyResolver.SetResolver( new AutofacDependencyResolver(container) );
        }

        private void RegisterServices()
        {
            builder.RegisterType<MysqlRepository>()
                .As<IDataRepository>()
                .InstancePerHttpRequest();

            builder.RegisterType<DalaranEntities>()
                .As<DbContext>()
                .InstancePerHttpRequest();
        }
    }
}