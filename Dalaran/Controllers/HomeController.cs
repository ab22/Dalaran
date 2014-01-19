using Dalaran.DAL;
using Dalaran.DAL.Interfaces;
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

        public HomeController( IDataRepository repository )
        {
            this.repository = repository;
        }
        public ActionResult Index()
        {
            List<string> names = new List<string>();

            List<Expression<Func<Users, object>>> includeList = new List<Expression<Func<Users, object>>>();
            includeList.Add(u => u.Cities.States.Countries);

            var users = repository.Select<Users>(x => true, includeList.AsQueryable());

            foreach (var u in users)
            {
                names.Add(String.Format("{0} - {1} - {2}", u.Cities.States.Countries.Name, u.Cities.States.Name, u.Cities.Name));
            }

            ViewBag.Users = names;
            return View();
        }
    }
}