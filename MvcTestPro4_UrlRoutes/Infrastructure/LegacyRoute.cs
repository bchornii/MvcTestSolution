using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcTestPro4_UrlRoutes.Infrastructure
{
    public class LegacyRoute : RouteBase
    {
        private readonly string[] _urlStrings;

        public LegacyRoute(string[] urlStrings)
        {
            _urlStrings = urlStrings;
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            RouteData result = null;

            var requestedUrl = httpContext.Request.AppRelativeCurrentExecutionFilePath;
            if (_urlStrings.Contains(requestedUrl, StringComparer.OrdinalIgnoreCase))
            {
                result = new RouteData(this, new MvcRouteHandler());
                result.Values.Add("controller","Legacy");
                result.Values.Add("action","GetLegacyUrl");
                result.Values.Add("legacyUrl", requestedUrl);
            }
            return result;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            VirtualPathData result = null;

            if (values.ContainsKey("legacyUrl") &&
                _urlStrings.Contains((string) values["legacyUrl"], StringComparer.OrdinalIgnoreCase))
            {
                result = new VirtualPathData(this, new UrlHelper(requestContext)
                                                               .Content((string)values["legacyUrl"]).Substring(1));
            }
            return result;
        }
    }
}