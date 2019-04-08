using Shop.Shared.Entities.Enums;
using Shop.Web.Attributes;
using System;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var cookie = new HttpCookie("test_cookie")
            {
                Value = DateTime.Now.ToString("dd.MM.yyyy"),
                Expires = DateTime.Now.AddMinutes(10),
            };
            Response.SetCookie(cookie);
            return View();
        }

        [SuperPuperAuthorize(roles: RoleType.Administrator)]
        public ActionResult About()
        {
            ViewBag.Message = "Информация";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Контакты";

            return View();
        }
    }
}