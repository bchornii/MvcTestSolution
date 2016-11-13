using System;
using System.Web.Mvc;
using MvcTestPro12_ModelValid.Models;

namespace MvcTestPro12_ModelValid.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult MakeBooking()
        {
            return View(new Appointment {Date = DateTime.Now});
        }

        [HttpPost]
        public ViewResult MakeBooking(Appointment appt)
        {
            //{
            //    if (string.IsNullOrEmpty(appt.ClientName))
            //        ModelState.AddModelError("ClientName", "Введите свое имя");

            //    if (ModelState.IsValidField("Date") && DateTime.Now > appt.Date)
            //        ModelState.AddModelError("Date", "Введите дату относящуюся к будущему");

            //    if (!appt.TermsAccepted)
            //        ModelState.AddModelError("TermsAccepted", "Вы должны принять условия");

            if (ModelState.IsValid)
            {
                // В реальном приложении здесь находились бы операторы
                // для сохранения нового объекта Appointment в базе данных
                return View("Completed", appt);
            }
            return View();
        }

        public JsonResult ValidateDate(string date)
        {
            DateTime parsedDate;

            if (!DateTime.TryParse(date, out parsedDate))
            {
                return Json("Пожалуйста, введите дату в формате (мм.дд.гггг)",
                    JsonRequestBehavior.AllowGet);
            }
            if (DateTime.Now > parsedDate)
            {
                return Json("Введите дату относящуюся к будущему json",
                    JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}