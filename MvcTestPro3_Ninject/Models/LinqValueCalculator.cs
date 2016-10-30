using System.Collections.Generic;
using System.Linq;

namespace MvcTestPro3_Ninject.Models
{
    public interface IValueCalculator
    {
        decimal ValueProducts(IEnumerable<Product> products);
    }
    public class LinqValueCalculator : IValueCalculator
    {
        private readonly IDiscountHelper _discountHelper;

        public LinqValueCalculator(IDiscountHelper discountHelper)
        {
            _discountHelper = discountHelper;
        }
        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return _discountHelper.ApplyDiscount(products.Sum(p => p.Price));
        }
    }
}