using System.Web.Mvc;
using MvcTestPro6_CtrlExt.Models;

namespace MvcTestPro6_CtrlExt.Controllers
{
    public class ProductController : Controller
    {
        public ViewResult Index()
        {
            return View("Result", new Result
            {
                ControllerName = "Product",
                ActionName = "Index"
            });
        }

        public ViewResult List()
        {
            return View("Result", new Result
            {
                ControllerName = "Product",
                ActionName = "List"
            });
        }
    }
}