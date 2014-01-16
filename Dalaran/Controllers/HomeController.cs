using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dalaran.DAL;
using Dalaran.DAL.Interfaces;

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
            var users = repository.Select<Users>( x => true );

            foreach (var u in users)
            {
                names.Add(u.Username);
            }
            ViewBag.Users = names;

            return View();
        }
    }
}