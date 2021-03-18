using Shop.Business.Services.Interfaces;
using Shop.Data.DataContext.Realization.MsSql;
using Shop.Data.Repositories;
using Shop.Shared.Entities;
using Shop.Shared.Entities.Enums;
using System.Collections.Generic;

namespace Shop.Business.Services
{
    public class RoleService : IRoleService
    {
        RoleRepository _roleRepository = new RoleRepository(new RoleContext());

        public void DeleteById(int id)
        {
            _roleRepository.DeleteById(id);
        }

        public IReadOnlyCollection<RoleType> GetAll()
        {
            return _roleRepository.GetAll();
        }

        public RoleType GetById(int id)
        {
            return _roleRepository.GetById(id);
        }

        public void Save(RoleType role)
        {
            _roleRepository.Save(role);
        }
    }
}
