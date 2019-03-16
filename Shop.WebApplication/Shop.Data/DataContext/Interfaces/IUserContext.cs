using Shop.Shared.Entities;

namespace Shop.Data.DataContext.Interfaces
{
    public interface IUserContext : IDataContext<User>
    {
        User GetAuthorizedUser(string login, string password);

        void Save(User user);
    }
}
