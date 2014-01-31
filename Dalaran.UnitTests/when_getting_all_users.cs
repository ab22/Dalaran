using System.Collections.Generic;
using Autofac;
using Dalaran.Controllers;
using Dalaran.Infrastructure;
using Dalaran.Models;
using Machine.Specifications;
using It = Machine.Specifications.It;
using Dalaran.Services.Casting;

namespace Dalaran.UnitTests
{
    public class when_getting_all_users
    {
        static HomeController _controller;
        static List<UserModel> _result;

        Establish context = 
            () =>
            {
                var container = new DalaranBootstrapper(new ContainerBuilder()).Run();
                
                _controller = container.Resolve<HomeController>();

            };
        Because of =
            () => _result = _controller.GetUsers().Data.As<List<UserModel>>();
        It should_return_all_users =
            () => _result.Count.ShouldBeGreaterThan(0);
        Cleanup after =
            () =>
                {

                };
    }
}
