using Shop.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Services.Interfaces
{
    public interface ILocationService
    {
        IReadOnlyCollection<Location> GetAll();

        void Save(Location location);

        int GetId(Location location);
    }
}
