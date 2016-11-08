using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTestPro11_Models.Models
{
    public class User
    {
        public int UserId { get; set; }

        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [DisplayName("Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DisplayName("Адрес")]
        public Address HomeAddress { get; set; }

        [DisplayName("Подтвердил регистрацию?")]
        public bool IsApproved { get; set; }

        [DisplayName("Роль")]
        public Role Role { get; set; }
    }
}