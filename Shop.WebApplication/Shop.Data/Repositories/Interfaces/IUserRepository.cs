using Shop.Shared.Entities;

namespace Shop.Data.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User Login(string login, string password);

        User Register(string login, string password, string email, string phone);

        void Save(User user);
    }
}
