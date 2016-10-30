using System.Web.Mvc;
using MvcTestPro2_Razor.Models;

namespace MvcTestPro2_Razor.Controllers
{
    public class HomeController : Controller
    {
        private readonly Product _myProduct = new Product
        {
            ProductId = 1,
            Name = "Каяк",
            Description = "Лодка на одного человека",
            Category = "Водные виды спорта",
            Price = 275M
        };


        // GET: Home
        public ActionResult Index()
        {
            return View(_myProduct);
        }

        public ActionResult NameAndPrice()
        {
            return View(_myProduct);
        }

        public ActionResult DemoExpression()
        {

            ViewBag.ProductCount = 1;
            ViewBag.ExpressShip = true;
            ViewBag.ApplyDiscount = false;
            ViewBag.Supplier = null;

            return View(_myProduct);
        }

        public ActionResult DemoArray()
        {
            Product[] array = {
                new Product {Name = "Каяк", Price = 275M},
                new Product {Name = "Спасательный жилет", Price = 48.95M},
                new Product {Name = "Футбольной мяч", Price = 19.50M},
                new Product {Name = "Угловой флажок", Price = 34.95M}
            };
            return View(array);
        }
    }
}