using System.Linq.Expressions;
using System.Web.Mvc;
using Dalaran.DAL.Entities;
using Dalaran.Models.Login;
using FizzWare.NBuilder;
using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dalaran.UnitTests.Home
{
    [Subject("Login Validation")]
    [Tags("Login", "Invalid Data")]
    public class when_user_logs_in_with_invalid_password : given_that_a_user_wants_to_authenticate
    {
        private static string _dummyEmail = "some@email.com";
        private static string _dummyPassword = "somepassword";
        private static string _messageKeyName = "LOGIN_INVALID_PASSWORD";
        private static string _invalidPasswordMessage = "Invalid password message";
        private static string _userPassword = "UserPassword";
        private static string _userPasswordSalt = "UserPasswordSalt";

        private static LoginResultModel _expectedLoginResultModel;
        private static JsonResult _result;
        Establish context =
            () =>
            {
                var userList = new List<User>()
                {
                    Builder<User>
                        .CreateNew()
                            .With(x => x.Password = _userPassword)
                            .With(x => x.PasswordSalt = _userPasswordSalt)
                                .Build()
                }.AsQueryable();

                DataRepositoryMock.Setup(
                        x => x.Select(Moq.It.IsAny<Expression<Func<User, bool>>>(), null)
                    ).Returns(userList);

                EncryptionServiceMock.Setup(
                        x => x.Compare( _userPassword, _userPasswordSalt, _dummyPassword )
                    ).Returns(false);

                MessageProviderMock.Setup(
                        x => x.GetMessage(_messageKeyName)
                    ).Returns(_invalidPasswordMessage);

                _expectedLoginResultModel = new LoginResultModel()
                {
                    Success = false,
                    Messages = new List<string>() { _invalidPasswordMessage }
                };
            };

        Because of =
            () => _result = HomeController.Login(_dummyEmail, _dummyPassword);

        It should_return_the_expected_result_model =
            () => _expectedLoginResultModel.ShouldBeLike(
                        JsonSerializerService.DeSerialize<LoginResultModel>(_result.Data.ToString())
                    );
    }
}
