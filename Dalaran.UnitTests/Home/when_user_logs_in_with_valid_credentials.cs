using System.Web;
using System.Web.Routing;
using System.Web.Security;
using Dalaran.Controllers;
using Dalaran.DAL.Entities;
using Dalaran.DAL.Interfaces;
using Dalaran.Models;
using Dalaran.Models.Login;
using Dalaran.Services;
using Dalaran.Services.Interfaces;
using FizzWare.NBuilder;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Dalaran.UnitTests.Home
{
    [Subject("Login Validation")]
    [Tags("Login")]
    public class when_user_logs_in_with_valid_credentials : given_that_a_user_wants_to_authenticate
    {
        private static LoginResultModel _expectedLoginResultModel;
        private static UserCookieModel _expectedUserCookieModel;
        private static JsonResult _result;

        private static int _userId = 22;
        private static string _userEmail = "test@test.com";
        private static string _userName = "Test Name";
        private static string _userLastName = "Test LastName";
        private static string _userPassword = "1234";

        Establish context =
            () =>
            {
                var userList = new List<User>()
                {
                    Builder<User>.CreateNew()
                        .With(x => x.UserId = _userId)
                        .With(x => x.Name = _userName)
                        .With(x => x.LastName = _userLastName)
                        .With(x => x.Email = _userEmail)
                        .With(x => x.Password = _userPassword)
                        .Build()
                };

                _expectedLoginResultModel = new LoginResultModel()
                {
                    Success = true,
                    Name = _userName,
                    LastName = _userLastName
                };

                _expectedUserCookieModel = new UserCookieModel
                {
                    UserId = _userId,
                    Email = _userEmail
                };
                
                DataRepositoryMock.Setup(
                        x => x.Select(Moq.It.IsAny<Expression<Func<User, bool>>>(), null)
                    ).Returns(userList.AsQueryable());

                EncryptionServiceMock.Setup(
                        x => x.Compare(
                            Moq.It.IsAny<string>(),
                            Moq.It.IsAny<string>(),
                            Moq.It.IsAny<string>()
                            )
                    ).Returns(true);
            };

        Because of =
            () => _result = HomeController.Login(_userEmail, _userPassword);

        It should_return_json_result =
            () =>
            {
                var result = JsonSerializerService.DeSerialize<LoginResultModel>(_result.Data.ToString());
                result.ShouldBeLike(_expectedLoginResultModel);
            };

        It should_set_a_valid_forms_authentication_cookie =
            () =>
            {
                var cookie = ResponseCookieCollection[FormsAuthentication.FormsCookieName];
                cookie.ShouldNotBeNull();

                var authenticationTicket = FormsAuthentication.Decrypt(cookie.Value);
                authenticationTicket.ShouldNotBeNull();

                var userCookieModel = JsonSerializerService.DeSerialize<UserCookieModel>(authenticationTicket.UserData);
                userCookieModel.ShouldBeLike(_expectedUserCookieModel);
            };
    }
}
