using System.Web.Mvc;
using MvcTestPro10_HelperMeths.Models;

namespace MvcTestPro10_HelperMeths.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Fruits = new string[] { "Яблоко", "Апельсин", "Груша" };
            ViewBag.Cities = new string[] { "Москва", "Лондон", "Париж" };

            string message = "Это HTML-элемент: <input>";

            return View((object)message);
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            return View("DisplayUser", user);
        }
    }
}