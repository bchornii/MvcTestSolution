using System;
using System.Web.Mvc;

namespace MvcTestPro5_Ctrls.Controllers
{
    public class HomeController : Controller
    {        
        public ViewResult Index()
        {
            ViewBag.Message = "Hello";
            return View(DateTime.Now);
        }

        public ViewResult HomePage()
        {
            return View("Homepage");
        }

        public ViewResult TestPage()
        {
            return View("Test");
        }

        public RedirectResult ProduceOutput()
        {
            //return new CustomRedirectResult {Url = "/Basic/Index"};
            return Redirect("/Basic/Index");
        }

        public RedirectToRouteResult RedirectRoute()
        {
            return RedirectToRoute(new
            {
                controller = "Basic",
                action = "Index",
                id = "MyId"
            });
        }

        public RedirectToRouteResult RedirectAction()
        {
            return RedirectToAction("Index", "Basic");
        }

        public RedirectToRouteResult RedirectTemp()
        {
            TempData["Message"] = "Hello";
            TempData["Date"] = DateTime.Now;
            return RedirectToAction("RedirectTempRead");
        }

        public ViewResult RedirectTempRead()
        {
            ViewBag.Message = TempData["Message"];
            ViewBag.Date = TempData["Date"];
            return View();
        }
    }
}