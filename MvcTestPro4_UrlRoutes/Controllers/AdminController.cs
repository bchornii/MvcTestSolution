using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTestPro4_UrlRoutes.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Controller = "Admin";
            ViewBag.Action = "Index";
            return View("ActionName");
        }
    }
}