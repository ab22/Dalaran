using Machine.Specifications;
using System;

namespace Dalaran.UnitTests.Home.Login
{
    [Subject("Login Validation")]
    [Tags("Login", "Security")]
    public class when_user_logs_in_with_invalid_parameters : given_that_a_user_wants_to_authenticate
    {
        private static string _veryLongEmail;
        private static string _veryLongPassword;
        private static Exception _exception;
        Establish context =
            () =>
            {
                _veryLongEmail = _veryLongPassword = null;
            };

        Because of =
            () => _exception = Catch.Exception(
                    () => HomeController.Login(_veryLongEmail, _veryLongPassword)
                );

        It should_throw_an_exception =
            () => _exception.ShouldBeOfType<ArgumentException>();
    }
}
