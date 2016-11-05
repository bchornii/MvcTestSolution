using System.Web.Mvc;
using System.Web.Routing;
using MvcTestPro6_CtrlExt.Infrastructure;

namespace MvcTestPro6_CtrlExt
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new DefaultControllerFactory(new CustomControllerActivator()));
            //ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory());
        }
    }
}
