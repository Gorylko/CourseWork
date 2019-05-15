using Shop.Data.DataContext.Realization.MsSql;
using Shop.Data.Repositories;
using Shop.Shared.Entities;
using System.Collections.Generic;

namespace Shop.Business.Services
{
    public class LocationService
    {
        LocationRepository _locationRepository = new LocationRepository(new LocationContext());
        public IReadOnlyCollection<Location> GetAll()
        {
            return _locationRepository.GetAll();
        }

        public void Save(Location location)
        {
            _locationRepository.Save(location);
        }

        public bool IsExists(Location location)
        {
            return _locationRepository.IsExists(location);
        }
    }
}
