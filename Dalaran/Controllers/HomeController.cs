using Dalaran.DAL;
using Dalaran.DAL.Entities;
using Dalaran.DAL.Interfaces;
using Dalaran.Infrastructure.Enumerations;
using Dalaran.Infrastructure.Interfaces;
using Dalaran.Models;
using Dalaran.Models.Login;
using Dalaran.Services.Interfaces;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using WebGrease.Css.Extensions;

namespace Dalaran.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataRepository _dataRepository;
        private readonly IEncryptionService _encryptionService;
        private readonly IJsonSerializerService _jsonSerializer;
        private readonly IMessageProvider _messageProvider;
        public const string UserNotFoundMessage = "";

        public HomeController( 
            IDataRepository dataRepository,
            IEncryptionService encryptionService,
            IJsonSerializerService jsonSerializer,
            IMessageProvider messageProvider
            )
        {
            _dataRepository = dataRepository;
            _encryptionService = encryptionService;
            _jsonSerializer = jsonSerializer;
            _messageProvider = messageProvider;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(string email, string password)
        {
            LoginResultModel resultModel;

            var user = _dataRepository.Select<User>(
                x => x.Email == email
                ).First();

            if (user == null) //Email not found
            {
                string errorMessage = _messageProvider.GetMessage("LOGIN_INVALID_CREDENTIALS");

                resultModel = new LoginResultModel()
                {
                    Success = false,
                    Messages = new List<string>() { errorMessage }
                };
            }
            else if (!_encryptionService.Compare(user.Password, user.PasswordSalt, password)) //Password doesn't match
            {
                string errorMessage = _messageProvider.GetMessage("LOGIN_INVALID_CREDENTIALS");

                resultModel = new LoginResultModel()
                {
                    Success = false,
                    Messages = new List<string>() {errorMessage}
                };
            }
            else //Valid credentials
            {
                resultModel = new LoginResultModel()
                {
                    Success = true,
                    Name = user.Name,
                    LastName = user.LastName
                };

                StartSession(user.UserId, user.Email);
            }

            string jsonResult = _jsonSerializer.Serialize(resultModel);
            return Json(jsonResult, JsonRequestBehavior.DenyGet);
        }

        private void StartSession(int userId, string email)
        {
            const int formsTicketVersion = 1;
            var userData = _jsonSerializer.Serialize(
                new UserCookieModel { 
                    UserId = userId,
                    Email = email
                }
            );

            var ticket = new FormsAuthenticationTicket(formsTicketVersion, email, DateTime.Now, DateTime.Now.AddMinutes(30), false, userData );
            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            Response.Cookies.Add(
                new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
                );
        }

        [HttpPost]
        public JsonResult Logout()
        {
            EndSession();

            return Json("", JsonRequestBehavior.DenyGet);
        }

        private void EndSession()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();

            var formsAuthCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "")
            {
                Expires = DateTime.Now.AddYears(-1)
            };
            Response.Cookies.Add(formsAuthCookie);

            var sessionAuthCookie = new HttpCookie("ASP.NET_SessionId", "")
            {
                Expires = DateTime.Now.AddYears(-1)
            };
            Response.Cookies.Add(sessionAuthCookie);
        }

        [HttpPost]
        public JsonResult GetUsers()
        {
            var users = _dataRepository.Select<User>
                (
                    u => u.City.State.Country.CountryId == 1
                );

            var result = Mapper.Map<IEnumerable<User>, List<UserModel>>(users);

            return Json
                (   
                    result,
                    JsonRequestBehavior.DenyGet
                );
        }

        void CreateUser()
        {
            var c = _dataRepository.Select<City>(x => x.CityId == 2).FirstOrDefault();
            var myUser = new User
            {
                AccountState = (int) AccountState.NotValidated,
                Address = "address",
                CityId = c.CityId,
                DoB = new DateTime(1990, 9, 22),
                Email = "email@gmail.com",
                Lastname = "Lastname",
                Name = "Firstname",
                PasswordSalt = _encryptionService.GenerateSalt()
            };

            myUser.Password = _encryptionService.Encrypt("1234", myUser.PasswordSalt);

            myUser.Rating = 0;
            myUser.RegisterDate = DateTime.Now;

            _dataRepository.Create<User>(myUser);
        }
    }
}