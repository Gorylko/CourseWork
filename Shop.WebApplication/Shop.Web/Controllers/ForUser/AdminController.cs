using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Shared.Entities;
using Shop.Shared.Entities.Enums;
using Helper = Shop.Shared.Helpers.RoleHelper;
using Shop.Web.Attributes;
using Shop.Web.Models;
using Shop.Business.Services;

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