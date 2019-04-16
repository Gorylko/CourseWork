using Shop.Shared.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Shop.Web.Models
{
    public class EditUserViewModel
    {
        [Required]
        [Display(Name ="Логин")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Почта")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Роль")]
        public string Role { get; set; } //сделать выборку через селет

        public RoleType[] AllRoles { get; set; }

        [Required]
        [Display(Name = "Телефон")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}