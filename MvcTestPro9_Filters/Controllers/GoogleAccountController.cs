using System.Web.Mvc;
using System.Web.Security;

namespace MvcTestPro9_Filters.Controllers
{
    public class GoogleAccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (username.EndsWith("@google.com") && password == "12345")
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return Redirect(Url.Action("List", "Home"));
            }
            ModelState.AddModelError("","Wrong user or password");
            return View();
        }
    }
}