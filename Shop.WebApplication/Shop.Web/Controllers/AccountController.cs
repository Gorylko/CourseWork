using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Shop.Web.Models;
using Shop.Shared.Entities;
using Shop.Shared.Entities.Enums;
using Shop.Business.Services;
using System.Data.SqlClient;

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
            try
            {
                _userService.Save(user); //В этом блоке эксепшн ловится именно отсюда, т.к. повторение логина и пароля запрещены еще при создании таблицы
                user.Role = RoleType.User;
                Session["User"] = user;
                ViewBag.User = user;
                return View();
            }
            catch (SqlException)
            {
                ViewBag.Warning = "Логин или почта уже заняты!";
                return View("~/Views/Account/Register.cshtml");
            }
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