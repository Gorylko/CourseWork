using Shop.Data.DataContext.Realization.MsSql;
using System.Collections.Generic;

namespace Shop.Data.Repositories
{
    public class LocationRepository //реализовать интерфейс
    { 
        LocationContext _locationContext = new LocationContext();

        public IReadOnlyCollection<string> GetAll()
        {
            return _locationContext.GetAll();
        }

        public int GetIdByName(string name)
        {
            return _locationContext.GetIdByName(name);
        }
        public void Save(string location)
        {
            _locationContext.Save(location);
        }
    }
}
