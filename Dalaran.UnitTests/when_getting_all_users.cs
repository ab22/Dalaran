using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Autofac;
using Dalaran.Controllers;
using Dalaran.DAL;
using Dalaran.DAL.Interfaces;
using Dalaran.Infrastructure;
using Dalaran.Models;
using Machine.Specifications;
using It = Machine.Specifications.It;
using Dalaran.Services.Casting;
using FizzWare.NBuilder;
namespace Dalaran.UnitTests
{
    [Subject("User Retrieval")]
    [Tags("Select", "Users")]
    public class when_getting_all_users
    {
        private static HomeController _controller;
        private static List<UserModel> _result;
        private static TransactionScope _transactionScope;
        private static IDataRepository _repository;
        private static Users _user;
        private static string _testEmail = "test@test.com";
        Establish context = 
            () =>
            {
                var container = new DalaranBootstrapper(new ContainerBuilder()).Run();
                _transactionScope = new TransactionScope();
                _controller = container.Resolve<HomeController>();
                _repository = container.Resolve<IDataRepository>();

                _user = Builder<Users>.CreateNew()
                    .With(x => x.UserId = 22)
                    .With(x => x.Email = _testEmail)
                    .Build();

                _repository.Create(_user);
            };
        Because of =
            () => _result = _controller.GetUsers().Data.As<List<UserModel>>();
        It should_return_all_users =
            () => _result.Count.ShouldBeGreaterThan(0);

        It should_select_one_user =
            () => _repository.Select<Users>(x => x.UserId == _user.UserId).FirstOrDefault().Email.ShouldEqual(_testEmail);

        private Cleanup after =
            () => _transactionScope.Dispose();
    }
}
