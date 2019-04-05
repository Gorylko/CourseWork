using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Shared.Entities;
using Shop.Shared.Entities.Enums;
using Shop.Shared.Entities.Authorize;

namespace Shop.Web.Attributes
{
    public class AdminAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = HttpContext.Current.User;
            if(user is UserPrinciple)
            {
                return user.IsInRole(RoleType.Administrator.ToString());
            }
            return false;
        }
    }
}