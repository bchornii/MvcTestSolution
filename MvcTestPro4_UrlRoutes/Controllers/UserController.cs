using System.Web.Mvc;

namespace MvcTestPro4_UrlRoutes.Controllers
{
    [RoutePrefix("Users")]
    public class UserController : Controller
    {
        [Route("~/Test")]
        public ActionResult Index() => View("ActionName");

        [HttpGet]
        [Route("Add/{user}/{id:int}")]
        public string Create(string user, int id) => $"User: {user}, id: {id}";

        [HttpGet]
        [Route("Add/{user}/{password:length(6)}")]
        public string ChangePassword(string user, string password) => $"User: {user}, password: {password}";
    }
}