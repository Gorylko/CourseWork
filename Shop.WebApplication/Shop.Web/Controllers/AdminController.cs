using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Shared.Entities;
using Shop.Shared.Entities.Enums;
using Helper = Shop.Shared.Helpers.RoleHelper;
using Shop.Web.Attributes;

namespace Shop.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        public ActionResult ShowAdminPanel()
        {
            if (!Helper.CheckPermissions((User)Session["User"], RoleType.Administrator, RoleType.Moderator))
            {                                                       //проверяет принадлежность к этим ролям
                ViewBag.Warning = "Ахтунг! Недостаточно прав для доступа к этой панели!";
                return View("~/Views/Shared/UserError.cshtml");
            }
            return View();
        }
    }
}