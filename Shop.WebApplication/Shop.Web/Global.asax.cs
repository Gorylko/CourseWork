using Newtonsoft.Json;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using Shop.Shared.Entities;
using Shop.Shared.Entities.Authorize;
using Shop.Web.Util;
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

            /*================Magic===============*/

            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
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
