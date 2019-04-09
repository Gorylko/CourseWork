using System.ComponentModel.DataAnnotations;

namespace Shop.Web.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Логин*")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Логин может содержать от 5 до 20 символов")]
        public string Login { get; set; }
    
        [Required]
        [Display(Name = "Пароль*")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Пароль может содержать от 6 до 16 символов")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Повторите пароль*")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; }

        [Required]
        [Display(Name = "Почта*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}