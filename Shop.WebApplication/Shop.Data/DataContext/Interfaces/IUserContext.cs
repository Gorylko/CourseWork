using Shop.Shared.Entities;
using System.Collections.Generic;

namespace Shop.Data.DataContext.Interfaces
{
    public interface IUserContext : IDataContext<User>
    {
        User GetUserByLoginAndPassword(string login, string password);

        User GetUserByLogin(string login);

        //User Register(string login, string password, string email, string phone);

        IReadOnlyCollection<User> GetAllByName(string searchQuery);
    }
}
