//using System.Security.Principal;
//using System.Web;
//using Shop.Shared.Entities;

//namespace Shop.Business.Services.Auth.Interfaces
//{
//    public interface IAuthentication
//    {
//        /// <summary>
//        /// Конекст (тут мы получаем доступ к запросу и кукисам)
//        /// </summary>
//        HttpContext HttpContext { get; set; }

//        User Login(string login, string password, bool isPersistent);

//        User Login(string login);

//        void LogOut();

//        IPrincipal CurrentUser { get; }

//    }
//}