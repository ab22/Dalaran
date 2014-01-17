using Dalaran.DAL;
using Dalaran.DAL.Interfaces;
using System.Collections.Generic;
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
            var users = repository.Select<Users>( x =>  true );
                     // repository.Select<User<( x => x.UserId == 1 ); 
                     // ^ Funciona tmb. Cualquier query loco que se te ocurra puede ir ahi

            foreach (var u in users)
            {
                names.Add(u.Username);
            }
            repository.UpdateMany(users);
            ViewBag.Users = names;
            return View();
        }
    }
}