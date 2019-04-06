using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Web.Controllers;
using Shop.Shared.Entities;

namespace Shop.Web.Attributes
{
    public class SuperPuperAuthorizeAttribute : AuthorizeAttribute
    {
        private string[] allowedUsers = new string[] { };
        private string[] allowedRoles = new string[] { };

        public string CurrentUserRole { get; set; }

        public string UserRole { get; set; }

        //public SuperPuperAuthorizeAttribute(User user) : base()
        //{
        //    this.CurrentUser = user;
        //}

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            AccountController controller = new AccountController();
            return base.AuthorizeCore(httpContext);
            //return controller.GetCurrentUser().ToString() == base.Roles;
        }

        private bool User(HttpContextBase httpContext)
        {
            if (allowedUsers.Length > 0)
            {
                return allowedUsers.Contains(httpContext.User.Identity.Name);
            }
            return true;
        }

        private bool Role(HttpContextBase httpContext)
        {
            if (allowedRoles.Length > 0)
            {
                for (int i = 0; i < allowedRoles.Length; i++)
                {
                    if (httpContext.User.IsInRole(allowedRoles[i]))
                        return true;
                }
                return false;
            }
            return true;
        }
    }

}
