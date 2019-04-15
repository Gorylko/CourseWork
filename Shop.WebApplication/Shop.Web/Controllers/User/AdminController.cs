using Shop.Business.Services;
using Shop.Shared.Entities;
using Shop.Web.Attributes;
using Shop.Web.Models;
using Shop.Web.Models.ProductViewModels;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class AdminController : Controller
    {
        private UserService _userService = new UserService();
        private ProductService _productService = new ProductService();
        private CategoryService _categoryService = new CategoryService();

        [Admin]
        public ActionResult ShowAdminPanel()
        {
            var model = new SiteStatViewModel()
            {
                ProductCount = _productService.GetAll().Count,
                UserCount = _userService.GetAll().Count
            };
            return View(model);
        }

        [Admin]
        public ActionResult AddNewCategory()
        {
            return View(new CategoryViewModel());
        }

        [Admin]
        [HttpPost]
        public ActionResult AddNewCategory(CategoryViewModel model)
        {
            _categoryService.Save(new Category { Name = model.CategoryName });
            return View("Views/Home/Index.cshtml");
        }

    }
}