using System.Web;
using System.Web.Routing;

namespace MvcTestPro4_UrlRoutes.Infrastructure
{
    public class CustomRouterHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext) => new CustomHttpHandler();
    }

    public class CustomHttpHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context) => context.Response.Write("Hello");

        public bool IsReusable => false;
    }
}