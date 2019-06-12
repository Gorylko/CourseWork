using Shop.Business.Services;
using Shop.Shared.Entities;
using Shop.Shared.Entities.Authorize;
using Shop.Shared.Entities.Enums;
using Shop.Web.Attributes;
using Shop.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Shop.Business.Services.Auth;
using EnumConverter = Shop.Shared.Helpers.EnumHelper;
using Shop.Business.Services.Interfaces;
using Shop.Business.Services.Auth.Interfaces;

namespace Shop.Web.Controllers
{
    public class UserController : Controller
    {
        private IProductService _productService;
        private IPurchaseService _purchaseService;
        private ICategoryService _categoryService;
        private IUserService _userService;
        private IStateService _stateService;
        private ILocationService _locationService;
        private IImageService _imageService;
        private IRoleService _roleService;
        private ILoginService _loginService;

        public UserController(
            IProductService productService,
            IPurchaseService purchaseService,
            ICategoryService categoryService,
            IUserService userService,
            IStateService stateService,
            ILocationService locationService,
            IImageService imageService,
            IRoleService roleService,
            ILoginService loginService)
        {
            this._productService = productService;
            this._purchaseService = purchaseService;
            this._categoryService = categoryService;
            this._userService = userService;
            this._stateService = stateService;
            this._locationService = locationService;
            this._imageService = imageService;
            this._roleService = roleService;
            this._loginService = loginService;
        }
        public ActionResult UserSearch()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ShowSearchUsers(SearchViewModel model)
        {
            var usersModel = new UserListViewModel();
            //if (!ModelState.IsValid)
            //{
            //    return PartialView(model);
            //}
            if (model.Name == null)
            {
                usersModel.Users = _userService.GetAll();
            }
            else
            {
                usersModel.Users = _userService.GetAllByName(model.Name);
            }
            return PartialView(usersModel);
        }

        [AllowAnonymous]
        public ActionResult ShowUser(string login)
        {
            var user = _userService.GetByLogin(login);
            ViewBag.User = user;
            ViewBag.Title = user.Login;
            return View();
        }

        [User]
        public ActionResult ShowCurrentUser()
        {
            var currentUser = User as UserPrinciple;
            var user = _userService.GetByLogin(currentUser.Name);
            return View(new UserViewModel
            {
                Login = user.Login,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role.ToString()
            });
        }

        [User]
        public ActionResult Delete()
        {
            var user = User as UserPrinciple;
            _productService.ArchiveAllByUserId(user.UserId);
            _imageService.DeleteAllByUserId(user.UserId);
            _userService.DeleteById(user.UserId);
            _loginService.Logout();
            return View("~/Views/Home/Index.cshtml");
        }

        [User]
        public ActionResult EditUser()
        {
            var currentUser = User as UserPrinciple;
            var user = _userService.GetById(currentUser.UserId);
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

        [User]
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
                Role = EnumConverter.ParseEnum<RoleType>(model.Role)
            });
            ViewBag.Message = $"Редактирование вашего аккаунта завершено успешно!";
            return View("~/Views/Shared/Notification.cshtml");
        }
        
        public ActionResult SendMessage(int id)
        {
            ViewBag.Message = $"Разработчик ленивая морда и не реализовал эту функцию";
            return View("~/Views/Shared/Notification.cshtml");
        }
    }
}