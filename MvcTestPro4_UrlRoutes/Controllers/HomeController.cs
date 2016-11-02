using System;
using System.Web.Mvc;

namespace MvcTestPro4_UrlRoutes.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "Index";
            return View("ActionName");
        }

        public ActionResult CustomVariable(string id)
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "CustomVariable";

            // The first approach for getting variables from URL template
            // ViewBag.CustomVariable = RouteData.Values["id"];

            // The second one is having a input parameters in action with the same
            // name as name of URL segment
            // When for optional parameter value has not been set then value of that variable will be 'null'
            ViewBag.CustomVariable = id;

            return View();
        }

        public RedirectToRouteResult MyActionMethod() => RedirectToAction("Index");

        public RedirectToRouteResult MyActionMethodV2() => RedirectToRoute(new
        {
            controller = "Home",
            action = "CustomVariable",
            id = "Hello from redirect"
        });

        [ChildActionOnly]
        public ActionResult Time(DateTime? userTime = null)
        {
            return PartialView(DateTime.Now);
        }
    }
}