using Shop.Shared.Entities.Authorize;
using Shop.Shared.Entities.Enums;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Attributes
{
    public class ModerAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = HttpContext.Current.User;
            if (user is UserPrinciple)
            {
                return user.IsInRole(RoleType.Moderator.ToString())
                    || user.IsInRole(RoleType.Administrator.ToString());
            }
            return false;
        }
    }
}