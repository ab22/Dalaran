using Autofac;
using Dalaran.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace Dalaran.Infrastructure
{
    public class DalaranBootstrapper : IBaseBootstrapper
    {
        private readonly ContainerBuilder builder;
        private readonly List<IGlobalConfiguration> _GlobalConfigurationList = new List<IGlobalConfiguration>();

        public DalaranBootstrapper(ContainerBuilder builder)
        {
            this.builder = builder;

            //Add Configuration classes
            _GlobalConfigurationList.Add(new WebConfiguration());
            _GlobalConfigurationList.Add(new AutoMapperWebConfiguration());
            _GlobalConfigurationList.Add(new AutoFacDependencyInjection(builder) );
        }

        public void Run()
        {
            _GlobalConfigurationList.ForEach( x => x.Configure() );
        }
    }
}