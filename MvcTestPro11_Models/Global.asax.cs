using System.Web.Mvc;
using System.Web.Routing;
using MvcTestPro11_Models.Infrastructure;

namespace MvcTestPro11_Models
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //ValueProviderFactories.Factories.Insert(index: 0, item: new CustomValueProviderFactory());

            ModelBinders.Binders.Add(typeof(MvcTestPro11_Models.Models.AdressSummary), new AddressSummaryBinder());
        }
    }
}
