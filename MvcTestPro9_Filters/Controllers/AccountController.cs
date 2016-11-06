using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcTestPro9_Filters.Controllers
{
    public class AccountController : Controller
    {        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password, string returnUrl)
        {
            bool result = FormsAuthentication.Authenticate(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return Redirect(Url.Action("Index", "Home"));
            }
            ModelState.AddModelError("", "Некорректное имя пользователя или пароль");
            return View();
        }
    }
}