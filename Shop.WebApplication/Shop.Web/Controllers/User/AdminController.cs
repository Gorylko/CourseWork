using Shop.Business.Services;
using Shop.Shared.Entities;
using Shop.Web.Attributes;
using Shop.Web.Models;
using Shop.Web.Models.ProductViewModels;
using System.Web.Mvc;
using Shop.Shared.Helpers;
using Shop.Shared.Entities.Enums;
using System;

namespace Shop.Web.Controllers
{
    public class AdminController : Controller
    {
        private UserService _userService = new UserService();
        private ProductService _productService = new ProductService();
        private CategoryService _categoryService = new CategoryService();
        private RoleService _roleService = new RoleService();
        private StateService _stateService = new StateService();
        private LocationService _locationService = new LocationService();

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
            ViewBag.Roles = _roleService.GetAll();
            return View(new EditUserViewModel
            {
                Id = user.Id,
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
                ViewBag.Roles = _roleService.GetAll();
                return View(model);
            }
            _userService.EditUser(new User
            {
                Id = model.Id,
                Login = model.Login,
                Email = model.Email,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                Role = EnumHelper.ParseEnum<RoleType>(model.Role)
            });
            ViewBag.Message = $"Пользователь {model.Login} изменён успешно!";
            return View("~/Views/Shared/Notification.cshtml");
        }

        [Moder]
        public ActionResult EditProduct(int id)
        {
            var product = _productService.GetProductById(id);
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.States = _stateService.GetAll();
            return View(new EditProductViewModel
            {
                Id = id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Author = product.Author,
                Price = product.Price,
                State = product.State,
                LocationOfProduct = product.LocationOfProduct
            });
        }

        [Moder]
        [HttpPost]
        public ActionResult EditProduct(EditProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _categoryService.GetAll();
                ViewBag.States = _stateService.GetAll();
                return View(model);
            }
            if (!_locationService.IsExists(model.LocationOfProduct))
            {
                _locationService.Save(model.LocationOfProduct);
            }
            _productService.Edit(new Shared.Entities.Product
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                LocationOfProduct = model.LocationOfProduct,
                LastModifiedDate = DateTime.Now,
                State = model.State,
                Category = model.Category,
                Author = model.Author
            });
            ViewBag.Message = $"Товар \"{model.Name}\" изменён успешно!";
            return View("~/Views/Shared/Notification.cshtml");
        }

        [Admin]
        public ActionResult AddNewUser()
        {
            ViewBag.Roles = _roleService.GetAll();
            return View(new EditUserViewModel());
        }

        [Admin]
        [HttpPost]
        public ActionResult AddNewUser(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Roles = _roleService.GetAll();
                return View(model);
            }
            _userService.Save(new User
            {
                Id = model.Id,
                Login = model.Login,
                Email = model.Email,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                Role = EnumHelper.ParseEnum<RoleType>(model.Role)
            });
            ViewBag.Message = $"Пользователь \"{model.Login}\" добавлен успешно!";
            return View("~/Views/Shared/Notification.cshtml");
        }
    }
}