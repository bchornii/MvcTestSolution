using System;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MvcTestPro4_UrlRoutes.Tests
{
    [TestClass]
    public class RouteTests
    {
        private static HttpContextBase CreateHttpContext(string targetUrl = null,
            string httpMethod = "GET")
        {
            // Create fake request
            var mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath)
                .Returns(targetUrl);
            mockRequest.Setup(m => m.HttpMethod)
                .Returns(httpMethod);
            mockRequest.Setup(m => m.UserAgent)
                .Returns("Chrome");

            // Create fake response
            var mockResponse = new Mock<HttpResponseBase>();
            mockResponse.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>()))
                .Returns<string>(s => s);

            // Create fake context which uses fake request/response
            var mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(m => m.Request)
                .Returns(mockRequest.Object);
            mockContext.Setup(m => m.Response)
                .Returns(mockResponse.Object);

            return mockContext.Object;
        }

        private static void TestRouteMatch(string url, string controller, string action, object routeProps = null,
            string httpMethod = "GET")
        {
            // Arrange
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            var result = routes.GetRouteData(CreateHttpContext(url, httpMethod));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(TestIncomingRouteResult(result, controller, action, routeProps));
        }

        private static bool TestIncomingRouteResult(RouteData routeResult, string controller, string action,
            object properties = null)
        {
            Func<object, object, bool> valCompare = (v1, v2) =>
                StringComparer.InvariantCultureIgnoreCase.Compare(v1, v2) == 0;

            var result = valCompare(routeResult.Values["controller"], controller) &&
                         valCompare(routeResult.Values["action"], action);

            if (properties == null) return result;
            var propInfo = properties.GetType().GetProperties();
            if (propInfo.Any(pi => !(routeResult.Values.ContainsKey(pi.Name) &&
                                     valCompare(routeResult.Values[pi.Name], pi.GetValue(properties, null)))))
            {
                result = false;
            }

            return result;
        }

        private static void TestRouteFail(string url, string httpMethod = "GET")
        {
            // Arrange
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            var result = routes.GetRouteData(CreateHttpContext(url, httpMethod));

            // Assert
            Assert.IsTrue(result?.Route == null);
        }

        // Empty URL
        [TestMethod]
        public void NoSegmentsInRoute_Test()
        {
            TestRouteMatch("~/", "Home", "Index");
        }

        // Public URL
        [TestMethod]
        public void PublicSegmentInRoute_Test()
        {
            TestRouteMatch("~/Public", "Home", "Index");
        }

        // Shop Url
        [TestMethod]
        public void ShopSegmentInRoute_Test()
        {
            TestRouteMatch("~/Shop", "Admin", "Index");
        }

        // Special vars : empty URL
        [TestMethod]
        public void SpecialRouteVar_EmptyRouteTest()
        {
            TestRouteMatch("~/", "Home", "Index");
        }

        // Special vars : controller name in URL
        [TestMethod]
        public void SpecialRouteVar_ControllerNameRouteTest()
        {
            TestRouteMatch("~/Home", "Home", "Index");
        }

        // Special vars : controller name and action name in URL
        [TestMethod]
        public void SpecialRouteVar_ControllerAndActionNameRouteTest()
        {
            TestRouteMatch("~/Home/Index", "Home", "Index");
        }

        // Catch all segment
        [TestMethod]
        public void CatchAllSegments_DeleteTest()
        {
            TestRouteMatch("~/Home/Index/All/Delete", "Home", "Index", 
                new { catchall = "Delete"});
        }

        // Catch all segment
        [TestMethod]
        public void CatchAllSegment_DeleteInsertTest()
        {
            TestRouteMatch("~/Home/Index/All/Delete/Insert", "Home", "Index",
                new { id = "All", catchall = "Delete/Insert" });
        }

        // Special vars : all segments in URL are present
        [TestMethod]
        public void SpecialRouteVar_AllRouteVarsPresentTest()
        {
            TestRouteMatch("~/Home/Index/All", "Home", "Index", new { id = "All" });
        }

        [TestMethod]
        public void TestAdminIndex_IncomingRequests()
        {
            TestRouteMatch("~/Admin/Index", "Admin", "Index");
        }

        [TestMethod]
        public void TestOneTwo_IncomingRequests()
        {
            TestRouteMatch("~/One/Two", "One", "Two");
        }
    }
}
