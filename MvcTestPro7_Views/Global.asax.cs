using System.Web.Mvc;
using System.Web.Routing;
using MvcTestPro7_Views.Infrastructure;

namespace MvcTestPro7_Views
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ViewEngines.Engines.Add(new DebugDataViewEngine());

            // **** View engines sequence matters
            // **** for set you engine as primary insert it :
            //ViewEngines.Engines.Insert(0, new DebugDataViewEngine());

            // **** Razor and ASPX is used
            // **** for make you engine single primary
            //ViewEngines.Engines.Clear();
            //ViewEngines.Engines.Add(new DebugDataViewEngine());
        }
    }
}
