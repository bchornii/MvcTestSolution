using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using MvcTestPro10_HelperMeths.Models;

namespace MvcTestPro10_HelperMeths.Controllers
{
    public class PeopleController : Controller
    {
        private List<User> _userData = new List<User> {
            new User {FirstName = "Иван", LastName = "Иванов", Role = Role.Admin},
            new User {FirstName = "Петр", LastName = "Петров", Role = Role.User},
            new User {FirstName = "Сидор", LastName = "Сидоров", Role = Role.User},
            new User {FirstName = "Вася", LastName = "Васильев", Role = Role.Guest}
        };

        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult GetPeople()
        //{
        //    return View(_userData);
        //}

        //[HttpPost]
        //public ActionResult GetPeople(string selectedRole)
        //{
        //    if (selectedRole == "All" || selectedRole == null)
        //    {
        //        return View(_userData);
        //    }
        //    var role = (Role) Enum.Parse(typeof(Role), selectedRole);
        //    return View(_userData.Where(u => u.Role == role).ToList());
        //}

        //public PartialViewResult GetPeopleData(string selectedRole = "All")
        //{
        //    IEnumerable<User> users = _userData;
        //    if (selectedRole != "All")
        //    {
        //        var role = (Role) Enum.Parse(typeof(Role), selectedRole);
        //        users = _userData.Where(u => u.Role == role);
        //    }
        //    Thread.Sleep(2000);
        //    return PartialView(users);
        //}
        //
        //public ViewResult GetPeople(string selectedRole = "All")
        //{
        //    return View((object) selectedRole);
        //}

        public IEnumerable<User> GetData(string selectedRole)
        {
            IEnumerable<User> users = _userData;
            if (selectedRole != "All")
            {
                var selected = (Role) Enum.Parse(typeof(Role), selectedRole);
                users = _userData.Where(u => u.Role == selected);
            }
            return users;
        }

        public JsonResult GetPeopleDataJson(string selectedRole = "All")
        {
            var users = GetData(selectedRole).Select(u => new 
            {
                u.FirstName,
                u.LastName,
                Role = Enum.GetName(typeof(Role), u.Role)
            }).ToList();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetPeopleData(string selectedRole = "All")
        {
            return PartialView(GetData(selectedRole).ToList());
        }

        public ViewResult GetPeople(string selectedRole = "All")
        {
            return View((object) selectedRole);
        }
    }
}