﻿using Dalaran.DAL;
using Dalaran.DAL.Interfaces;
using Dalaran.Infrastructure.Enumerations;
using Dalaran.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Dalaran.Controllers
{
    public class HomeController : Controller
    {
        private IDataRepository repository;
        private IEncryptionService encryptionService;
        public HomeController( 
            IDataRepository repository,
            IEncryptionService encryptionService
            )
        {
            this.repository = repository;
            this.encryptionService = encryptionService;
        }
        public ActionResult Index()
        {
            List<string> names = new List<string>();

            List<Expression<Func<Users, object>>> includeList = new List<Expression<Func<Users, object>>>();
            includeList.Add(u => u.Cities.States.Countries);

            var users = repository.Select<Users>(x => true, includeList.AsQueryable());
            if (users.Count() <= 1)
            {
                CreateUser();
            }

            foreach (var u in users)
            {
                names.Add(String.Format("{0} - {1} - {2}", u.Cities.States.Countries.Name, u.Cities.States.Name, u.Cities.Name));
            }

            ViewBag.Users = names;
            return View();
        }

        void CreateUser()
        {

            Cities c = repository.Select<Cities>(x => x.CityId == 2).FirstOrDefault();
            Users myUser = new Users();
            myUser.AccountState = (int)AccountState.NotValidated;
            myUser.Address = "6 y 7 calle, 4ta ave., bo. El Centro.";
            myUser.CityId = c.CityId;
            myUser.DOB = new DateTime(1990, 9, 22);
            myUser.Email = "abelardo22.9@gmail.com";
            myUser.Lastname = "Mendoza";
            myUser.Name = "Abelardo";

            myUser.PasswordSalt = encryptionService.GenerateSalt();
            myUser.Password = encryptionService.Encrypt("1234", myUser.PasswordSalt);

            myUser.Rating = 0;
            myUser.RegisterDate = DateTime.Now;

            repository.Create<Users>(myUser);
        }
    }
}