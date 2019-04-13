using Shop.Data.Repositories;
using System.Collections.Generic;

namespace Shop.Business.Services
{
    public class LocationService //реализовать интерфейс
    {
        LocationRepository _locationRepository = new LocationRepository();
        public IReadOnlyCollection<string> GetAll()
        {
            return _locationRepository.GetAll();
        }

        public int GetIdByName(string name)
        {
            return _locationRepository.GetIdByName(name);
        }

        public void Save(string location)
        {
            _locationRepository.Save(location);
        }

        public bool IsExists(string name)
        {
            if(_locationRepository.GetIdByName(name) == 0)
            {
                return false;
            }
            return true;

        }
    }
}
