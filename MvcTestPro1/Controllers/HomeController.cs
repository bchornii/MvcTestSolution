using System;
using System.Web.Mvc;
using MvcTestPro1.Models;
using System.Web.Helpers;

namespace MvcTestPro1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index()
        {
            ViewBag.Greeting = DateTime.Now.Hour < 12 ? "Good morning" : "Good evening";
            return View();
        }

        [HttpGet]
        public ActionResult RsvpForm()
        {
            return View(new GuestResponse { Message = "Ok"});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ViewResult RsvpForm(GuestResponse guest)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", guest);
            }
            return View();
        }
    }
}