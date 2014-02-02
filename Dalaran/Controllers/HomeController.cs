using Dalaran.DAL;
using Dalaran.DAL.Entities;
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
            var list = new List<String>();
            var navProperties = new List<Expression<Func<City, object>>> {x => x.State.Country};
            var countries = _repository.Select<City>(
                x => true,
                navProperties.AsQueryable()
                );
            
            countries.ForEach(
                x => 
                     list.Add(
                        String.Format("City {2} is in State {1} which is in country {0}", x.State.Country.Name, x.State.Name, x.Name)
                     )
                    );

            ViewBag.Countries = list;

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
            var users = _repository.Select<User>
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
            var c = _repository.Select<City>(x => x.CityId == 2).FirstOrDefault();
            var myUser = new User
            {
                AccountState = (int) AccountState.NotValidated,
                Address = "6 y 7 calle, 4ta ave., bo. El Centro.",
                CityId = c.CityId,
                DoB = new DateTime(1990, 9, 22),
                Email = "abelardo22.9@gmail.com",
                LastName = "Mendoza",
                Name = "Abelardo",
                PasswordSalt = _encryptionService.GenerateSalt()
            };

            myUser.Password = _encryptionService.Encrypt("1234", myUser.PasswordSalt);

            myUser.Rating = 0;
            myUser.RegisterDate = DateTime.Now;

            _repository.Create<User>(myUser);
        }
    }
}