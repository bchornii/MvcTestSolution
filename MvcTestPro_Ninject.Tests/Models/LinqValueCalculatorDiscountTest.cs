using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcTestPro3_Ninject.Models;

namespace MvcTestPro_Ninject.Tests.Models
{
    [TestClass]
    public class LinqValueCalculatorDiscountTest
    {
        private IEnumerable<Product> CreateProduct(decimal value)
        {
            return new[] { new Product { Price = value } };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Pass_Through_Variable_Discounts()
        {
            // arrange
            var discountMock = new Mock<IDiscountHelper>();
            discountMock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>()))
                .Returns<decimal>(t => t);
            discountMock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v == 0)))
                .Throws<ArgumentOutOfRangeException>();
            discountMock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v > 100)))
                .Returns<decimal>(t => t*0.9M);
            discountMock.Setup(m => m.ApplyDiscount(It.IsInRange<decimal>(10, 100, Range.Inclusive)))
                .Returns<decimal>(t => t - 5);
            var target = new LinqValueCalculator(discountMock.Object);

            // act
            var fiveDollarDiscount = target.ValueProducts(CreateProduct(5));
            var tenDollarDiscount = target.ValueProducts(CreateProduct(10));
            var fiftyDollarDiscount = target.ValueProducts(CreateProduct(50));
            var hundredDollarDiscount = target.ValueProducts(CreateProduct(100));
            var fiveHundredDollarDiscount = target.ValueProducts(CreateProduct(500));

            // Assert
            Assert.AreEqual(5, fiveDollarDiscount, "$5 потеряем");
            Assert.AreEqual(5, tenDollarDiscount, "$10 потеряем");
            Assert.AreEqual(45, fiftyDollarDiscount, "$50 потеряем");
            Assert.AreEqual(95, hundredDollarDiscount, "$100 потеряем");
            Assert.AreEqual(450, fiveHundredDollarDiscount, "$500 Fail");
            target.ValueProducts(CreateProduct(0));
        }
    }
}
