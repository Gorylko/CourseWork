using Shop.Business.Services;
using Shop.Web.Attributes;
using Shop.Web.Models;
using System.Web.Mvc;

namespace Shop.Web.Controllers.ForUser
{
    public class AdminController : Controller
    {
        private UserService _userService = new UserService();
        private ProductService _productService = new ProductService();

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
    }
}