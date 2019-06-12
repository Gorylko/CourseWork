using Shop.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Services.Interfaces
{
    public interface IUserService
    {
        IReadOnlyCollection<User> GetAll();

        void EditUser(User user);

        IReadOnlyCollection<User> GetAllByName(string searchQuery);

        void Save(User user);

        User GetById(int id);

        User GetByLogin(string name);

        void DeleteById(int id);
    }
}
