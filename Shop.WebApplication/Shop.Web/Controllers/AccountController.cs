using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Shop.Web.Models;
using Shop.Shared.Entities;
using Shop.Shared.Entities.Enums;
using Shop.Business.Services;

namespace Shop.Web.Controllers
{
    public class AccountController : Controller
    {
        private UserService _userService = new UserService();


        public ActionResult Login()
        {
            return View();
        }

        public ActionResult FinishLogin(string login, string password)
        {

            User user = _userService.GetAuthorizedUser(login, password);
            if (user == null)
            {
                ViewBag.Warning = "Неверный логин или пароль";
                return View("~/Views/Account/Login.cshtml");
            }
            Session["User"] = user;
            ViewBag.User = user;
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult FinishRegistration(User user)
        {
            user.Role = RoleType.User;
            Session["User"] = user;
            _userService.Save(user);
            ViewBag.User = user;
            return View();
        }

        public ActionResult OpenAccountMenu()
        {
            return View();
        }

        public ActionResult Exit()
        {
            Session["User"] = null;
            return View("~/Views/Home/Index.cshtml");
        }
    }
}