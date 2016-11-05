using System.Web.Mvc;
using System.Web.SessionState;
using MvcTestPro6_CtrlExt.Models;

namespace MvcTestPro6_CtrlExt.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class FastController : Controller
    {
        // GET: Fast
        public ActionResult Index()
        {            
            return View("Result", new Result
            {
                ControllerName = "Fast ",
                ActionName = "Index"
            });
        }
    }
}