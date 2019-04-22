using Shop.Data.DataContext.Realization.MsSql;
using Shop.Data.Repositories;
using Shop.Shared.Entities;
using System;
using System.Collections.Generic;

namespace Shop.Business.Services
{
    public class UserService
    {
        UserRepository _userRepository = new UserRepository(new UserContext());

        public IReadOnlyCollection<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public void EditUser(User user)
        {
            _userRepository.EditUser(user);
        }

        public IReadOnlyCollection<User> GetAllByName(string searchQuery)
        {
            return _userRepository.GetAllByName(searchQuery);
        }

        public void Save(User user)
        {
            _userRepository.Save(user);
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User GetByLogin(string name)
        {
            return _userRepository.GetUserByLogin(name); // _userRepository.Login(name);
        }

        public void DeleteById(int id)
        {
            _userRepository.DeleteById(id);
        }
    }
}
