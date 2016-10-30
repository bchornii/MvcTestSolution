using System.Collections.Generic;

namespace MvcTestPro3_Ninject.Models
{
    public interface IShoppingCart
    {        
        decimal CalculateProductTotal(IEnumerable<Product> products);
    }

    public class ShoppingCart : IShoppingCart
    {
        private readonly IValueCalculator _calculator;        

        public ShoppingCart(IValueCalculator calculator)
        {
            _calculator = calculator;
        }        

        public decimal CalculateProductTotal(IEnumerable<Product> products)
        {
            return _calculator.ValueProducts(products);
        }
    }
}