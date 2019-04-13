using Shop.Shared.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.Web.Models.ProductViewModels
{
    
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Название может содержать от 5 до 20 символов")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Описание")]
        [StringLength(525, ErrorMessage = "Описание может содержать не больше 525-ти символов")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Цена")]
        [Range(typeof(decimal), "0.00", "999999.99", ErrorMessage ="Некорректная цена")]
        public decimal Price { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public Category Category { get; set; }

        public User Author { get; set; }

        [Required]
        [Display(Name = "Местонахождение товара")]
        public string LocationOfProduct { get; set; }

        [Required]
        [Display(Name = "Состояние товара")]
        public State State { get; set; }
    }
}