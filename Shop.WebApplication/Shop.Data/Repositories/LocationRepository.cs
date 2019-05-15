using Shop.Data.DataContext.Realization.MsSql;
using System.Collections.Generic;
using Shop.Data.Repositories.Interfaces;
using Shop.Shared.Entities;
using Shop.Data.DataContext.Interfaces;

namespace Shop.Data.Repositories
{
    public class LocationRepository : IProductDetailsRepository<Location>
    {
        IProductDetailsContext<Location> _locationContext;

        public LocationRepository(IProductDetailsContext<Location> context)
        {
            _locationContext = context;
        }

        public IReadOnlyCollection<Location> GetAll()
        {
            return _locationContext.GetAll();
        }

        public void Save(Location location)
        {
            _locationContext.Save(location);
        }

        public void DeleteById(int id)
        {
            _locationContext.DeleteById(id);
        }

        public Location GetById(int id)
        {
            return _locationContext.GetById(id);
        }

        public bool IsExists(Location location)
        {
            return _locationContext.IsExists(location);
        }
    }
}
