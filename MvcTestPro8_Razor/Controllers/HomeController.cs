using System;
using System.Web.Mvc;

namespace MvcTestPro8_Razor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string[] names = { "Яблоко", "Апельсин", "Груша" };
            return View(names);            
        }

        public ViewResult List()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult Time()
        {
            return PartialView(DateTime.Now);
        }
    }
}