using System.Web.Mvc;
using Shop.Business.Services;
using Shop.Web.Models;
namespace Shop.Web.Controllers.ForUser
{
    public class UserController : Controller
    {
        UserService _userService = new UserService();

        public ActionResult ShowUsersList()
        {
            ViewBag.Users = _userService.GetAll();
            return View(new SearchViewModel());
        }

        [HttpPost]
        public ActionResult ShowUsersList(SearchViewModel model)
        {
            if (model.Name == null)
            {
                ViewBag.Users = _userService.GetAll();
            }
            else
            {
                ViewBag.Users = _userService.GetAllByName(model.Name);
            }
            return View(model);
        }
        
        public ActionResult ShowUser(string login)
        {
            var user = _userService.GetByName(login);
            ViewBag.User = user;
            ViewBag.Title = user.Login;
            return View();
        }
    }
}