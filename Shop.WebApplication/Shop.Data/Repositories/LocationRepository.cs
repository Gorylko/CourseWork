using Shop.Data.DataContext.Realization.MsSql;
using Shop.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
