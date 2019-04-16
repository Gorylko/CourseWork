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
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _categoryService.Save(new Category { Name = model.CategoryName });
            ViewBag.Message = $"Категория {model.CategoryName} успешно добавлена!";
            return View("~/Views/Shared/Notification.cshtml");
        }

        [Admin]
        public ActionResult EditUser(int id)
        {
            var user = _userService.GetById(id);
            return View(new EditUserViewModel
            {
                Login = user.Login,
                Email = user.Email,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role.ToString()
            });
        }

        [Admin]
        [HttpPost]
        public ActionResult EditUser(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return View("~/Views/Shared/Notification.cshtml");
        }
    }
}