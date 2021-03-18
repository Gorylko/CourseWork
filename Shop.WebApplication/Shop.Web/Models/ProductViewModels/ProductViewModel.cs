using Shop.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Shop.Shared.Entities.Images;

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
        [DataType(DataType.MultilineText)]
        [StringLength(525, ErrorMessage = "Описание может содержать не больше 525-ти символов")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastModifiedDate { get; set; }

        [Required]
        public Category Category { get; set; }

        public IReadOnlyCollection<Category> Categories { get; set; }


        public User Author { get; set; }

        [Required]
        [Display(Name = "Местонахождение товара")]
        public Location Location { get; set; }

        public IReadOnlyCollection<Image> Images { get; set; }

        [Required]
        [Display(Name = "Состояние товара")]
        public State State { get; set; }

        public IReadOnlyCollection<State> States { get; set; }
    }
}