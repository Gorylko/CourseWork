using System.Collections.Generic;
using Shop.Shared.Entities;
using Shop.Data.DataContext.Interfaces;
using Shop.Data.Repositories.Interfaces;

namespace Shop.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        IUserContext _userContext;

        public UserRepository(IUserContext userContext)
        {
            this._userContext = userContext;
        }

        public User GetAuthorizedUser(string login, string password)
        {
            return _userContext.GetAuthorizedUser(login, password);
        }

        public void Save(User user)
        {
            _userContext.Save(user);
        }

        public IReadOnlyCollection<User> GetAll()
        {
            return _userContext.GetAll();
        }

        public User GetById(int id)
        {
            return _userContext.GetById(id);
        }

        public void DeleteById(int id)
        {
            _userContext.DeleteById(id);
        }

        public IReadOnlyCollection<User> GetAllByName(string searchQuery)
        {
            return _userContext.GetAllByName(searchQuery);
        }
    }
}
