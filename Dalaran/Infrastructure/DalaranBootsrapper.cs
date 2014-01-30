using Autofac;
using Autofac.Integration.Mvc;
using Dalaran.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Dalaran.Infrastructure
{
    public class DalaranBootstrapper : IBaseBootstrapper
    {
        private readonly ContainerBuilder _builder;
        private readonly List<IGlobalConfiguration> _globalConfigurationList = new List<IGlobalConfiguration>();

        public DalaranBootstrapper(ContainerBuilder builder)
        {
            this._builder = builder;

            //Add Configuration classes
            _globalConfigurationList.Add(new WebConfiguration());
            _globalConfigurationList.Add(new AutoMapperWebConfiguration());
            _globalConfigurationList.Add(new AutoFacDependencyInjection(builder) );
        }

        public ILifetimeScope Run()
        {
            _globalConfigurationList.ForEach( x => x.Configure() );

            var container = _builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }
    }
}