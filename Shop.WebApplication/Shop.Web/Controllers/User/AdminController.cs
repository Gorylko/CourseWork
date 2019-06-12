using Shop.Business.Services;
using Shop.Shared.Entities;
using Shop.Web.Attributes;
using Shop.Web.Models;
using Shop.Web.Models.ProductViewModels;
using System.Web.Mvc;
using Shop.Shared.Helpers;
using Shop.Shared.Entities.Enums;
using System;
using Shop.Business.Services.Auth;
using Shop.Business.Services.Interfaces;

namespace Shop.Web.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;
        private IPurchaseService _purchaseService;
        private ICategoryService _categoryService;
        private IUserService _userService;
        private IStateService _stateService;
        private ILocationService _locationService;
        private IImageService _imageService;
        private IRoleService _roleService;

        public AdminController(
            IProductService productService,
            IPurchaseService purchaseService,
            ICategoryService categoryService,
            IUserService userService,
            IStateService stateService,
            ILocationService locationService,
            IImageService imageService,
            IRoleService roleService)
        {
            this._productService = productService;
            this._purchaseService = purchaseService;
            this._categoryService = categoryService;
            this._userService = userService;
            this._stateService = stateService;
            this._locationService = locationService;
            this._imageService = imageService;
            this._roleService = roleService;
        }

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
        public ActionResult DeleteUser(int userId)
        {
            ViewBag.Message = $"Пользователь \"{_userService.GetById(userId).Login}\" удален успешно!";
            _productService.ArchiveAllByUserId(userId);
            _imageService.DeleteAllByUserId(userId);
            _userService.DeleteById(userId);
            return View("~/Views/Shared/Notification.cshtml");
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
                Id = user.Id,
                Login = user.Login,
                Email = user.Email,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role.ToString(),
                Roles = _roleService.GetAll()
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
                Location = product.Location
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
            _locationService.Save(model.Location);
            model.Location.Id = _locationService.GetId(model.Location);
            _productService.Edit(new Shared.Entities.Product
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Location = model.Location,
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