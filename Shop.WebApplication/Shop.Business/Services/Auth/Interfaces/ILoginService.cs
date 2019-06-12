using Shop.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Services.Auth.Interfaces
{
    public interface ILoginService
    {
        User Login(string login, string password);

        User Register(string login, string password, string email, string phone);

        void Logout();
    }
}
