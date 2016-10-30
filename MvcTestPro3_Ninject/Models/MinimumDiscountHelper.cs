using System;

namespace MvcTestPro3_Ninject.Models
{
    public class MinimumDiscountHelper : IDiscountHelper
    {
        public decimal ApplyDiscount(decimal totalParam)
        {
            throw new Exception();
        }
    }
}