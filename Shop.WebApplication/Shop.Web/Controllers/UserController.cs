using System.Web.Mvc;
using Shop.Business.Services;
namespace Shop.Web.Controllers
{
    public class UserController : Controller
    {
        UserService _userService = new UserService();

        public ActionResult ShowUsersMenu()
        {
            ViewBag.Users = _userService.GetAll();
            return View();
        }

        public ActionResult ShowUsersMenu(string searchQuery)
        {
            ViewBag.Users = _userService.GetAllByName(searchQuery);
            return View();
        }        
    }
}