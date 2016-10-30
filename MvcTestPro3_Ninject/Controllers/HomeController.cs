using System.Web.Mvc;
using MvcTestPro3_Ninject.Models;
using Ninject;

namespace MvcTestPro3_Ninject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IShoppingCart _shoppingCart;
        private readonly Product[] _products = {
            new Product {Name = "Каяк", Category = "Водные виды спорта", Price = 275M},
            new Product {Name = "Спасательный жилет", Category = "Водные виды спорта", Price = 48.95M},
            new Product {Name = "Мяч", Category = "Футбол", Price = 19.50M},
            new Product {Name = "Угловой флажок", Category = "Футбол", Price = 34.95M}
        };

        public HomeController(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;            
        }

        // GET: Home
        public ActionResult Index()
        {
            var totalValue = _shoppingCart.CalculateProductTotal(_products);
            return View(totalValue);
        }
    }
}