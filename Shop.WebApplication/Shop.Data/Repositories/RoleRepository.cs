using Shop.Data.DataContext.Interfaces;
using Shop.Data.Repositories.Interfaces;
using Shop.Shared.Entities;
using Shop.Shared.Entities.Enums;
using System.Collections.Generic;

namespace Shop.Data.Repositories
{
    public class RoleRepository : IRepository<RoleType>
    {
        private IDataContext<RoleType> _roleContext;

        public RoleRepository(IDataContext<RoleType> context)
        {
            this._roleContext = context;
        }

        public void DeleteById(int id)
        {
            _roleContext.DeleteById(id);
        }

        public IReadOnlyCollection<RoleType> GetAll()
        {
            return _roleContext.GetAll();
        }

        public RoleType GetById(int id)
        {
            return _roleContext.GetById(id);
        }

        public void Save(RoleType role)
        {
            _roleContext.Save(role);
        }
    }
}
