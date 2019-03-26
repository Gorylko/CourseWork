using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Shared.Entities;
using Shop.Shared.Entities.Enums;
using Helper = Shop.Shared.Helpers.RoleHelper;

namespace Shop.Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
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