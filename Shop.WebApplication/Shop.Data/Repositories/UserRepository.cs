using Shop.Data.DataContext.Interfaces;
using Shop.Data.Repositories.Interfaces;
using Shop.Shared.Entities;
using System.Collections.Generic;

namespace Shop.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserContext _userContext;

        public UserRepository(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public User GetUserByLoginAndPassword(string login, string password)
        {
            return _userContext.GetUserByLoginAndPassword(login, password);
        }

        public User GetUserByLogin(string login)
        {
            return _userContext.GetUserByLogin(login);
        }

        // низя так делать
        //public User Register(string login, string password, string email, string phone)
        //{
        //    return _userContext.Register(login, password, email, phone);
        //}

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
