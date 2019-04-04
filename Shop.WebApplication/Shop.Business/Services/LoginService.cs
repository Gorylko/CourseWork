using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Shared.Entities;
using Shop.Data.Repositories;
using Shop.Data.DataContext.Realization.MsSql;
using Shop.Shared.Entities.Authorize;
using System.Web.Security;

namespace Shop.Business.Services
{
    public class LoginService
    {
        UserRepository _userRepository = new UserRepository(new UserContext());
        public MembershipUser Login(string login, string password)
        {
            User user = _userRepository.GetAuthorizedUser(login, password);
            return new MembershipUser
            {
                UserId = user.Id,
                Name = user.Login,
                Role = user.Role
            };
        }

        public MembershipUser Register(string login, string password, string email, string phone)
        {
            User user = _userRepository.RegisterUser(login, password, email, phone);
            return new MembershipUser
            {
                UserId = user.Id,
                Name = user.Login,
                Role = user.Role
            };
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}
