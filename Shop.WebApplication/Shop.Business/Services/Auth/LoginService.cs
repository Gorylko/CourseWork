using System;
using Shop.Shared.Entities;
using Shop.Data.Repositories;
using Shop.Data.DataContext.Realization.MsSql;
using System.Web.Security;
using System.Web;
using Newtonsoft.Json;

namespace Shop.Business.Services.Auth
{
    public class LoginService
    {
        private readonly UserRepository _userRepository = new UserRepository(new UserContext());
        private const int VERSION = 1;

        public User Login(string login, string password)
        {
            if (this.GetUserByLoginAndPassword(login, password) is User user)
            {
                this.SetCookies(user);
                return user;
            }

            return default(User);
        }

        public User Register(string login, string password, string email, string phone)
        {
            var newUser = new User
            {
                Login = login,
                Email = email,
                Password = password,
                PhoneNumber = phone,
            };
            _userRepository.Save(newUser);

            var user = _userRepository.GetUserByLogin(login);
            return user ?? null;
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        private User GetUserByLoginAndPassword(string login, string password)
        {
            return _userRepository.GetUserByLoginAndPassword(login, password);
        }

        private void SetCookies(User user)
        {
            var userData = JsonConvert.SerializeObject(user);
            var ticket = new FormsAuthenticationTicket(VERSION, user.Login, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData);
            var encryptTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}
