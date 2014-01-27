using Dalaran.DAL;
using Dalaran.DAL.Interfaces;
using Dalaran.Infrastructure.CustomAttributes;
using Dalaran.Infrastructure.Enumerations;
using Dalaran.Models;
using Dalaran.Services.Interfaces;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Dalaran.Controllers
{
    public class HomeController : Controller
    {
        private IDataRepository _repository;
        private IEncryptionService _encryptionService;
        private IJsonSerializerService _jsonSerializer;
        public HomeController( 
            IDataRepository repository,
            IEncryptionService encryptionService,
            IJsonSerializerService jsonSerializer
            )
        {
            this._repository = repository;
            this._encryptionService = encryptionService;
            this._jsonSerializer = jsonSerializer;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(string Email, string Password)
        {
            //if( database.users.matches(email, password){
            //this.StartSession(0, Email);
            //}
            return Json( "Done" , JsonRequestBehavior.DenyGet);
        }

        private void StartSession(int UserId, string Email)
        {
            string  userData = _jsonSerializer.Serialize(
                new UserCookieModel { 
                    UserId = UserId,
                    Email = Email
                }
            );

            var ticket = new FormsAuthenticationTicket(1, Email, DateTime.Now, DateTime.Now.AddMinutes(30), false, userData );
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);

            Response.Cookies.Add(
                new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
                );
        }

        [HttpPost]
        public JsonResult Logout()
        {
            this.EndSession();

            return Json("", JsonRequestBehavior.DenyGet);
        }

        private void EndSession()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();

            HttpCookie formsAuthCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            formsAuthCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(formsAuthCookie);

            HttpCookie sessionAuthCookie = new HttpCookie("ASP.NET_SessionId", "");
            sessionAuthCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(sessionAuthCookie);
        }

        void CreateUser()
        {
            Cities c = _repository.Select<Cities>(x => x.CityId == 2).FirstOrDefault();
            Users myUser = new Users();
            myUser.AccountState = (int)AccountState.NotValidated;
            myUser.Address = "6 y 7 calle, 4ta ave., bo. El Centro.";
            myUser.CityId = c.CityId;
            myUser.DOB = new DateTime(1990, 9, 22);
            myUser.Email = "abelardo22.9@gmail.com";
            myUser.Lastname = "Mendoza";
            myUser.Name = "Abelardo";

            myUser.PasswordSalt = _encryptionService.GenerateSalt();
            myUser.Password = _encryptionService.Encrypt("1234", myUser.PasswordSalt);

            myUser.Rating = 0;
            myUser.RegisterDate = DateTime.Now;

            _repository.Create<Users>(myUser);
        }
    }
}