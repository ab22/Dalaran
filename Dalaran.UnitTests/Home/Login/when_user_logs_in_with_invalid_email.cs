using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Dalaran.DAL.Entities;
using Dalaran.Models.Login;
using Machine.Specifications;
using System;
using System.Linq.Expressions;

namespace Dalaran.UnitTests.Home
{
    [Subject("Login Validation")]
    [Tags("Login", "Invalid Data")]
    public class when_user_logs_in_with_invalid_email : given_that_a_user_wants_to_authenticate
    {
        private static string _dummyEmail = "some@email.com";
        private static string _dummyPassword = "somepassword";
        private static string _messageKeyName = "LOGIN_INVALID_CREDENTIALS";
        private static string _invalidEmailMessage = "Invalid email message";

        private static LoginResultModel _expectedLoginResultModel;
        private static JsonResult _result;
        Establish context =
            () =>
            {
                var emptyUserList = new List<User>().AsQueryable();

                DataRepositoryMock.Setup(
                        x => x.Select(Moq.It.IsAny<Expression<Func<User, bool>>>(), null)
                    ).Returns(emptyUserList);

                MessageProviderMock.Setup(
                        x => x.GetMessage(_messageKeyName)
                    ).Returns(_invalidEmailMessage);

                _expectedLoginResultModel = new LoginResultModel()
                {
                    Success = false,
                    Messages = new List<string>() { _invalidEmailMessage }
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
