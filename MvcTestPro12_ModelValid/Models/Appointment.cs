using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcTestPro12_ModelValid.Models
{
    public class Appointment
    {
        [Required(ErrorMessage = "Введите свое имя")]
        [StringLength(10, MinimumLength = 3)]
        public string ClientName { get; set; }

        [DataType(DataType.Date)]
        [Remote("ValidateDate", "Home")]
        public DateTime Date { get; set; }

        public bool TermsAccepted { get; set; }
    }
}