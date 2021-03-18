using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories.Interfaces
{
    public interface ILocationRepository<TLocation> : IRepository<TLocation>
    {

        int GetId(TLocation location);
    }
}
