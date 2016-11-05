using System.Web.Mvc;

namespace MvcTestPro6_CtrlExt.Controllers
{
    public class ActionInvokerController : Controller
    {
        public ActionInvokerController()
        {
            ActionInvoker = new CustomActionInvoker();
        }
    }
}