using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTestPro4_UrlRoutes.AdditionalController
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Controller = "AdditionalController.Home";
            ViewBag.Action = "Index";
            return View("ActionName");
        }
    }
}