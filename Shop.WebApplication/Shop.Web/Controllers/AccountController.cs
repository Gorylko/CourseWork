using System;
using System.Web;
using System.Web.Mvc;
using Shop.Web.Models;
using Shop.Business.Services;
using Microsoft.Owin.Security;
using System.Web.Security;
using Newtonsoft.Json;
using Shop.Shared.Entities.Authorize;
using System.Data.SqlClient;

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
            SendCookies(_loginService.Login(model.Login, model.Password));
            if(Session["User"] == null)
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
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                Session["User"] = _loginService.Register(model.Login, model.Password, model.Email, model.PhoneNumber);
                
            }
            catch(SqlException)
            {
                ViewBag.ErrorMessage = "логин или почта уже заняты";
                return View(model);
            }

            return Redirect("/Home/Index");
        }

        private void SendCookies(Shared.Entities.Authorize.MembershipUser user)
        {
            var userData = JsonConvert.SerializeObject(user);
            var ticket = new FormsAuthenticationTicket(VERSION, user.Name, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData);
            var encryptTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
            System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
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