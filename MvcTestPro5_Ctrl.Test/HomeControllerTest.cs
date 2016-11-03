using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTestPro5_Ctrls.Controllers;

namespace MvcTestPro5_Ctrl.Test
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexActionTest()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            ViewResult result = controller.Index();

            // Assert
            Assert.AreEqual("", result.ViewName);
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(DateTime));
            Assert.AreEqual("Hello", result.ViewBag.Message);
        }

        [TestMethod]
        public void HomepageActionTest()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            ViewResult result = controller.HomePage();

            // Assert
            Assert.AreEqual("Homepage", result.ViewName);
        }

        [TestMethod]
        public void ProduceOutputTest()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            RedirectResult result = controller.ProduceOutput();

            // Assert
            Assert.AreEqual("/Basic/Index", result.Url);
        }

        [TestMethod]
        public void RedirectRouteTest()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            RedirectToRouteResult result = controller.RedirectRoute();

            // Assert
            Assert.IsFalse(result.Permanent);
            Assert.AreEqual("Basic", result.RouteValues["controller"]);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("MyId", result.RouteValues["id"]);
        }

        [TestMethod]
        public void RedurectActionTest()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            RedirectToRouteResult result = controller.RedirectAction();

            // Assert
            Assert.IsFalse(result.Permanent);
            Assert.AreEqual("Basic", result.RouteValues["controller"]);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNull(result.RouteValues["id"]);            
        }
    }
}
