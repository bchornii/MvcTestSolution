using System.ComponentModel.DataAnnotations;

namespace MvcTestPro1.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Please, enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, enter you email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "You typed wrong email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, enter your phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please, confirm you tralala")]
        public bool? WillAttend { get; set; }

        public string Message { get; set; }
    }
}