using Shop.Business.Services.Interfaces;
using Shop.Data.DataContext.Realization.MsSql;
using Shop.Data.Repositories;
using Shop.Shared.Entities;
using System.Collections.Generic;

namespace Shop.Business.Services
{
    public class LocationService : ILocationService
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

        public int GetId(Location location)
        {
            return _locationRepository.GetId(location);
        }
    }
}
