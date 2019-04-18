using Newtonsoft.Json;
using Shop.Shared.Entities;
using Shop.Shared.Entities.Authorize;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace Shop.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs arg)
        {
            var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null)
            {
                var ticket = FormsAuthentication.Decrypt(cookie.Value);
                var user = JsonConvert.DeserializeObject<User>(ticket.UserData);
                var userPrinciple = new UserPrinciple(user.Login)
                {
                    UserId = user.Id,
                    Role = user.Role
                };

                HttpContext.Current.User = userPrinciple;
            }
        }
    }
}
