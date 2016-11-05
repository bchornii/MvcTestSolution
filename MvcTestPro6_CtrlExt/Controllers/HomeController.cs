using System.Web.Mvc;
using MvcTestPro6_CtrlExt.Infrastructure;
using MvcTestPro6_CtrlExt.Models;

namespace MvcTestPro6_CtrlExt.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Result", new Result
            {
                ControllerName = "Home",
                ActionName = "Index"
            });
        }

        [Local]
        [ActionName("Index")]
        public ActionResult LocalIndex()
        {
            return View("Result", new Result
            {
                ControllerName = "Home",
                ActionName = "LocalIndex"
            });
        }

        protected override void HandleUnknownAction(string actionName)
        {
            Response.Write($"You asked action <b>{actionName}</b>");
        }
    }
}