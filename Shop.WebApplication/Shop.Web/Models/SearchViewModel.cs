using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Shop.Shared.Entities;

namespace Shop.Web.Models
{
    public class SearchViewModel
    {
        [Display(Name = "Введите ваш запрос")]
        [StringLength(20, ErrorMessage = "запрос может содержать до 20 символов")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        //позже добавлю
    }
}