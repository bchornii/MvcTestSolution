using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcTestPro3_Ninject.Models;

namespace MvcTestPro3_Ninject.Models.Tests
{
    [TestClass()]
    public class LinqValueCalculatorTests
    {
        private readonly Product[] _products = {
            new Product {Name = "Каяк", Category = "Водные виды спорта", Price = 275M},
            new Product {Name = "Спасательный жилет", Category = "Водные виды спорта", Price = 48.95M},
            new Product {Name = "Мяч", Category = "Футбол", Price = 19.50M},
            new Product {Name = "Угловой флажок", Category = "Футбол", Price = 34.95M}
        };

        [TestMethod()]
        public void ValueProductsTest()
        {
            // Arrange                        
            var discountMock = new Mock<IDiscountHelper>();
            discountMock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>()))
                .Returns<decimal>(t => t);
            var target = new LinqValueCalculator(discountMock.Object);
            var goalTotal = _products.Sum(e => e.Price);

            // Act
            var result = target.ValueProducts(_products);

            // Assert
            Assert.AreEqual(goalTotal, result);
        }
    }
}