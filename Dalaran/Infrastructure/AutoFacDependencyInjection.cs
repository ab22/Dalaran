using Autofac;
using Autofac.Integration.Mvc;
using Dalaran.DAL;
using Dalaran.DAL.Interfaces;
using Dalaran.DAL.Repositories;
using Dalaran.Infrastructure.Interfaces;
using Dalaran.Services;
using Dalaran.Services.Interfaces;
using System.Data.Entity;

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
        }

        private void RegisterServices()
        {
            builder.RegisterType<DalaranEntities>()
                .As<DbContext>();

            builder.Register(c => new MysqlRepository(c.Resolve<DbContext>()))
                .As<IDataRepository>();

            builder.RegisterType<SHAEncryptionService>()
                .As<IEncryptionService>();

            builder.RegisterType<JsonSerializerService>()
                .As<IJsonSerializerService>();
        }
    }
}