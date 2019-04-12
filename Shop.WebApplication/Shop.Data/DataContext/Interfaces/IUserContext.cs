using Shop.Shared.Entities;
using System.Collections.Generic;

namespace Shop.Data.DataContext.Interfaces
{
    public interface IUserContext : IDataContext<User>
    {
        User GetUserByLoginAndPassword(string login, string password);

        User GetUserByLogin(string login);

        IReadOnlyCollection<User> GetAllByName(string searchQuery);
    }
}
