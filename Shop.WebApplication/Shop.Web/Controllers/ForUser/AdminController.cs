using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Shared.Entities;
using Shop.Shared.Entities.Enums;
using Helper = Shop.Shared.Helpers.RoleHelper;
using Shop.Web.Attributes;

namespace Shop.Web.Controllers.ForUser
{
    public class AdminController : Controller
    {
        [Admin]
        public ActionResult ShowAdminPanel()
        {
            return View();
        }
    }
}