using System;
using System.Web.Mvc;
using MvcTestPro9_Filters.Infrastructure;

namespace MvcTestPro9_Filters.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Users = "user")]
        public string Index()
        {
            return "Это метод действия Index в контроллере Home";
        }

        [GoogleAuth]
        [Authorize(Users = "osvyatobog@google.com")]        
        public string List()
        {
            return "Это метод действия List в контроллере Home";
        }

        //[RangeException]
        [HandleError(ExceptionType = typeof(ArgumentOutOfRangeException), View = "RangeError")]
        public string RangeTest(int id)
        {
            if (id > 100)
            {
                return $"Значение ID: {id}";
            }
            throw new ArgumentOutOfRangeException(nameof(id), id, "");
        }

        [CustomAction(true)]
        [ProfileAction]
        [ProfileResult]
        [ProfileAll]
        public string FilterTest()
        {
            return "This is method FilterTest in Home controller";
        }        
    }
}