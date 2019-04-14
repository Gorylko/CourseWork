using System.ComponentModel.DataAnnotations;

namespace Shop.Web.Models.ProductViewModels
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }

        [Required]
        [Display(Name ="Название новой категории")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Название новой категории может содержать лишь от 5 до 15 символов")]
        public string CategoryName { get; set; }
    }
}