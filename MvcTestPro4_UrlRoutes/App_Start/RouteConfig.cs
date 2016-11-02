using MvcTestPro4_UrlRoutes.Infrastructure;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcTestPro4_UrlRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Mvc route attributes
            routes.MapMvcAttributeRoutes();

            // Custom http handler
            //routes.Add(new Route("SayHello", new CustomRouterHandler()));

            // Custom route
            routes.Add(new LegacyRoute(new []{
                "~/articles/About_ASPNET_MVC",
                "~/old/NET_Framework_4"
            }));

            //routes.MapRoute("NewRoute",
            //    url: "App/Do{action}",
            //    defaults: new { controller = "Home" });

            // Route with 3 segments
            //routes.MapRoute(name: "CustomRoute1",
            //    url: "Public/{controller}/{action}",
            //    defaults: new { action = "Index", controller = "Home" });

            //// Route with pseudonym for controller
            //routes.MapRoute(name: "CustomRoute2",
            //    url: "Shop/{action}",
            //    defaults: new { action = "Index", controller = "Admin" });

            // The most common route (the least common from top)
            // When use namespace then MVC first of all looking for controller there, and if it couldn't find appropriate
            // controller then MVC gets standart behaviour and looks everywhere
            // When we want for looking just in single namespace for controller we can set 'UseNamespaceFallback' property as false
            var r = routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{*catchall}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MvcTestPro4_UrlRoutes.Controllers" }
                //constraints: new
                //{
                //    id = new CompoundRouteConstraint(new IRouteConstraint[]
                //    {
                //        new AlphaRouteConstraint(),
                //        new LengthRouteConstraint(0,5)
                //    }),
                //    custom = new UserAgentConstraint("Chrome")
                //}
            );
            r.DataTokens["UseNamespaceFallback"] = false;

            //routes.MapRoute(name: "Default", 
            //    url: "{controller}/{action}");
        }
    }
}
