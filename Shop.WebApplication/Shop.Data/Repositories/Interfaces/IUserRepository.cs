using Shop.Shared.Entities;

namespace Shop.Data.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByLogin(string login);

        User GetUserByLoginAndPassword(string login, string password);

        void EditUser(User user);
    }
}
