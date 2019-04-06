using System;
using System.Web;
using System.Web.Mvc;
using Shop.Web.Models;
using Shop.Business.Services.Auth;
using Microsoft.Owin.Security;
using System.Web.Security;
using Newtonsoft.Json;
using Shop.Shared.Entities.Authorize;
using Shop.Business.Services;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity.EntityFramework;
using Shop.Shared.Entities;

namespace Shop.Web.Controllers
{
    public class AccountController : Controller
    {
        private const int VERSION = 1;
        private UserService _userService = new UserService();
        private LoginService _loginService = new LoginService();

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var user = _loginService.Login(model.Login, model.Password);
            if (user == null)
            {
                ViewBag.ErrorMessage = "Ахтунг! Ашыбка, проверьте введенные данные";
                return View(model);
            }
            Session["User"] = user;
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
                var identityClaim = new IdentityUserClaim { ClaimType = "Role", ClaimValue = user.Role.ToString() };
                //user.Claims = identityClaim;
                HttpContext.User = new UserPrinciple(model.Login)
                {
                    UserId = user.Id,
                    Name = user.Login,
                    Role = user.Role
                };
            }
            catch(SqlException)
            {
                ViewBag.ErrorMessage = "логин или почта уже заняты";
                return View(model);
            }

            return Redirect("/Home/Index");
        }



        public ActionResult OpenAccountMenu()
        {
            return View();
        }

        public ActionResult Logout()
        {
            _loginService.Logout();
            return View("~/Views/Home/Index.cshtml");
        }
    }
}