using Shop.Shared.Entities.Authorize;
using Shop.Shared.Entities.Enums;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Attributes
{
    public class SuperPuperAuthorizeAttribute : AuthorizeAttribute
    {
        //private string[] allowedUsers = new string[] { };
        private RoleType[] _roles = new RoleType[] { };

        public SuperPuperAuthorizeAttribute(params RoleType[] roles)
        {
            _roles = roles;
        }

        //public string CurrentUserRole { get; set; }

        //public string UserRole { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var currentUser = HttpContext.Current.User;
            if (!(currentUser is UserPrinciple))
            {
                return false;
            }

            foreach (var role in _roles)
            {
                if (!currentUser.IsInRole(role.ToString()))
                {
                    return false;
                }
            }

            return true;
        }

        //private bool User(HttpContextBase httpContext)
        //{
        //    if (allowedUsers.Length > 0)
        //    {
        //        return allowedUsers.Contains(httpContext.User.Identity.Name);
        //    }
        //    return true;
        //}

        //private bool Role(HttpContextBase httpContext)
        //{
        //    if (allowedRoles.Length > 0)
        //    {
        //        for (int i = 0; i < allowedRoles.Length; i++)
        //        {
        //            if (httpContext.User.IsInRole(allowedRoles[i]))
        //                return true;
        //        }
        //        return false;
        //    }
        //    return true;
        //}
    }

}
