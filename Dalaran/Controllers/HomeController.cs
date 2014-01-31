using Dalaran.DAL;
using Dalaran.DAL.Interfaces;
using Dalaran.Infrastructure.Enumerations;
using Dalaran.Models;
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
        private readonly IDataRepository _repository;
        private readonly IEncryptionService _encryptionService;
        private readonly IJsonSerializerService _jsonSerializer;
        public HomeController( 
            IDataRepository repository,
            IEncryptionService encryptionService,
            IJsonSerializerService jsonSerializer
            )
        {
            _repository = repository;
            _encryptionService = encryptionService;
            _jsonSerializer = jsonSerializer;
        }
        public ActionResult Index()
        {
            var navigationProperties = new List<Expression<Func<Users, object>>>
            {
                x => x.Cities.States.Countries
            };

            var users = _repository.Select(
                u => u.Cities.States.Countries.CountryId == 1,
                navigationProperties.AsQueryable()
                );

            var userList = new List<String>();
            users.ForEach
                (u =>
                    {
                        if (true)
                        {
                            userList.Add(String.Format("{0} - {1} - {2}", u.Name, u.Lastname, u.Cities.Name));
                        }
                    }
                );

            ViewBag.UserList = userList;

            return View();
        }

        [HttpPost]
        public JsonResult Login(string email, string password)
        {
            //if( database.users.matches(email, password){
            //this.StartSession(0, Email);
            //}
            return Json( "Done" , JsonRequestBehavior.DenyGet);
        }

        private void StartSession(int userId, string email)
        {
            string  userData = _jsonSerializer.Serialize(
                new UserCookieModel { 
                    UserId = userId,
                    Email = email
                }
            );

            var ticket = new FormsAuthenticationTicket(1, email, DateTime.Now, DateTime.Now.AddMinutes(30), false, userData );
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);

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
            var users = _repository.Select<Users>
                (
                    u => u.Cities.States.Countries.CountryId == 1
                );

            var result = Mapper.Map<IEnumerable<Users>, List<UserModel>>(users);

            return Json
                (   
                    result,
                    JsonRequestBehavior.DenyGet
                );
        }

        void CreateUser()
        {
            var c = _repository.Select<Cities>(x => x.CityId == 2).FirstOrDefault();
            var myUser = new Users
            {
                AccountState = (int) AccountState.NotValidated,
                Address = "6 y 7 calle, 4ta ave., bo. El Centro.",
                CityId = c.CityId,
                DOB = new DateTime(1990, 9, 22),
                Email = "abelardo22.9@gmail.com",
                Lastname = "Mendoza",
                Name = "Abelardo",
                PasswordSalt = _encryptionService.GenerateSalt()
            };

            myUser.Password = _encryptionService.Encrypt("1234", myUser.PasswordSalt);

            myUser.Rating = 0;
            myUser.RegisterDate = DateTime.Now;

            _repository.Create<Users>(myUser);
        }
    }
}