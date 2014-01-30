
using Autofac;
namespace Dalaran.Infrastructure.Interfaces
{
    public interface IBaseBootstrapper
    {
        ILifetimeScope Run();
    }
}