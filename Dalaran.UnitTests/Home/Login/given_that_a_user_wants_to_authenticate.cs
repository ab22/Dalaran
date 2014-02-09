using System;
using System.Linq.Expressions;
using Dalaran.Controllers;
using Dalaran.DAL.Entities;
using Dalaran.DAL.Interfaces;
using Dalaran.Infrastructure.Interfaces;
using Dalaran.Services;
using Dalaran.Services.Interfaces;
using Machine.Specifications;
using Moq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Dalaran.UnitTests.Home
{
    [Subject("User Login")]
    [Tags("Login", "Base Class")]
    public class given_that_a_user_wants_to_authenticate
    {
        protected static Mock<HttpContextBase> HttpContextMock;
        protected static Mock<HttpResponseBase> HttpResponseMock;
        protected static RequestContext RequestContext;
        protected static ControllerContext ControllerContext;

        protected static HomeController HomeController;
        protected static Mock<IDataRepository> DataRepositoryMock;
        protected static Mock<IEncryptionService> EncryptionServiceMock;
        protected static Mock<IMessageProvider> MessageProviderMock;
        protected static IJsonSerializerService JsonSerializerService;

        protected static HttpCookieCollection ResponseCookieCollection;
        Establish context =
            () =>
            {
                HttpContextMock = new Mock<HttpContextBase>();
                HttpResponseMock = new Mock<HttpResponseBase>();
                DataRepositoryMock = new Mock<IDataRepository>();
                EncryptionServiceMock = new Mock<IEncryptionService>();
                MessageProviderMock = new Mock<IMessageProvider>();
                JsonSerializerService = new JsonSerializerService();

                ResponseCookieCollection = new HttpCookieCollection();

                HttpContextMock.Setup(
                    x => x.Response
                    ).Returns(HttpResponseMock.Object);

                HttpResponseMock.Setup(
                    x => x.Cookies
                    ).Returns(ResponseCookieCollection);
                
                HomeController = new HomeController(
                        DataRepositoryMock.Object,
                        EncryptionServiceMock.Object,
                        JsonSerializerService,
                        MessageProviderMock.Object
                    );

                RequestContext = new RequestContext(HttpContextMock.Object, new RouteData());
                ControllerContext = new ControllerContext(RequestContext, HomeController);
                HomeController.ControllerContext = ControllerContext;
            };
    }
}
