using Shop.Shared.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Services.Interfaces
{
    public interface IRoleService
    {
        void DeleteById(int id);

        IReadOnlyCollection<RoleType> GetAll();

        RoleType GetById(int id);

        void Save(RoleType role);
    }
}

