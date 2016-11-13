using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcTestPro11_Models.Models;

namespace MvcTestPro11_Models.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<User> _userCollection = new List<User> {
            new User {UserId = 1, FirstName = "Иван", LastName = "Иванов", Role = Role.Admin},
            new User {UserId = 2, FirstName = "Петр", LastName = "Петров", Role = Role.User},
            new User {UserId = 3, FirstName = "Сидор", LastName = "Сидоров", Role = Role.User},
            new User {UserId = 4, FirstName = "Вася", LastName = "Васильев", Role = Role.Guest}
        };
        
        public ActionResult Index(int id)
        {
            var user = _userCollection.FirstOrDefault(u => u.UserId == id);
            return View(user);
        }

        public ActionResult DisplaySummary([Bind(Prefix = "HomeAddress")]AdressSummary summary)
        {
            return View(summary);
        }

        public ActionResult Names(string[] names)
        {
            names = names ?? new string[0];
            return View(names);
        }

        //public ActionResult Address(List<AdressSummary> addresses)
        //{
        //    addresses = addresses ?? new List<AdressSummary>();
        //    return View(addresses);
        //}

        public ActionResult Address()
        {
            var addresses = new List<AdressSummary>();
            UpdateModel(addresses);
            return View(addresses);
        }

        public ActionResult CreateUser()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult CreateUser(User model)
        {
            return View("Index", model);
        }
    }
}