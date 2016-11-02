using System.Web.Mvc;
using System.Web.Routing;

namespace MvcTestPro5_Ctrls.Controllers
{
    public class BasicController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            var controller = (string)requestContext.RouteData.Values["controller"];
            var action = (string)requestContext.RouteData.Values["action"];

            requestContext.HttpContext.Response.Write($"Контроллер: {controller}, Метод действия: {action}");
        }
    }
}