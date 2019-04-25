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

        [Display(Name = "Минимальная цена")]
        public decimal MinPrice { get; set; }

        [Display(Name = "Максимальная цена")]
        public decimal MaxPrice { get; set; }

        [Display(Name = "Состояние")]
        public State State { get; set; }

        [Display(Name = "Категория")]
        public Category Category { get; set; }
    }
}