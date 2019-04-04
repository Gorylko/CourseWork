using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Shared.Entities;
using Shop.Data.Repositories;
using Shop.Data.DataContext.Realization.MsSql;
using Shop.Shared.Entities.Authorize;

namespace Shop.Business.Services
{
    public class UserService
    {
        UserRepository _userRepository = new UserRepository(new UserContext());

        public IReadOnlyCollection<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public IReadOnlyCollection<User> GetAllByName(string searchQuery)
        {
            return _userRepository.GetAllByName(searchQuery);
        }

        public void Save(User user)
        {
            _userRepository.Save(user);
        }

    }
}
