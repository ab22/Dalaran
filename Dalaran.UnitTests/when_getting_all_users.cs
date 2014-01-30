using Autofac;
using Dalaran.Controllers;
using Dalaran.Infrastructure;
using Dalaran.Models;
using Machine.Specifications;
using System.Collections.Generic;
using System.Web.Mvc;
using It = Machine.Specifications.It;

namespace Dalaran.UnitTests
{
    public class when_getting_all_users
    {
        static HomeController _controller;
        static JsonResult _result;

        Establish context = 
            () =>
            {
                var container = new DalaranBootstrapper(new ContainerBuilder()).Run();
                
                _controller = container.Resolve<HomeController>();

            };
        Because of =
            () => _result = _controller.GetUsers();
        It should_return_all_users =
            () => ((List<UserModel>)_result.Data).Count.ShouldBeGreaterThan(0);
        Cleanup after =
            () =>
                {

                };
    }
}
