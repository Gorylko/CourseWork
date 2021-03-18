using Shop.Business.Services;
using Shop.Business.Services.Auth;
using Shop.Business.Services.Auth.Interfaces;
using Shop.Business.Services.Interfaces;
using Shop.Web.Attributes;
using Shop.Web.Models;
using Shop.Web.Models.Shared;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class AccountController : Controller
    {
        private const int VERSION = 1;
        private IUserService _userService;
        private ILoginService _loginService;

        public AccountController(
            IUserService userService,
            ILoginService loginService)
        {
            this._userService = userService;
            this._loginService = loginService;
        }

        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = _loginService.Login(model.Login, model.Password);
            if (user == null)
            {
                ViewBag.ErrorMessage = "Ахтунг! Ашыбка, проверьте введенные данные";
                return View(model);
            }
            return Redirect("/Home/Index");
        }

        public ActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var user = _loginService.Register(model.Login, model.Password, model.Email, model.PhoneNumber);
                if (user != null)
                {
                    return RedirectToAction("Login");
                }
            }
            catch (SqlException)
            {
                ViewBag.ErrorMessage = "логин или почта уже заняты";
                return View(model);
            }

            return Redirect("/Home/Index");
        }

        [User]
        public ActionResult Logout()
        {
            _loginService.Logout();
            //return View("~/Views/Home/Index.cshtml");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Confirm(ConfirmViewModel model)
        {
            return View(model);
        }


    }
}