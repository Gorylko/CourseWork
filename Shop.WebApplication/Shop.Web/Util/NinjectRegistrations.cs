using Ninject.Modules;
using Shop.Business.Services;
using Shop.Business.Services.Auth;
using Shop.Business.Services.Auth.Interfaces;
using Shop.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductService>();
            Bind<IPurchaseService>().To<PurchaseService>();
            Bind<ICategoryService>().To<CategoryService>();
            Bind<IUserService>().To<UserService>();
            Bind<IStateService>().To<StateService>();
            Bind<ILocationService>().To<LocationService>();
            Bind<IImageService>().To<ImageService>();
            Bind<ILoginService>().To<LoginService>();
            Bind<IRoleService>().To<RoleService>();
        }
    }
}