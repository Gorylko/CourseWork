using System.ComponentModel.DataAnnotations;

namespace Shop.Web.Models
{
    public class EditUserViewModel
    {
        [Display(Name ="Логин")]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Почта")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Роль")]
        public string Role { get; set; }

        [Display(Name = "Телефон")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}