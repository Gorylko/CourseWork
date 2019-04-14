using Shop.Data.DataContext.Realization.MsSql;
using System.Collections.Generic;
using Shop.Data.Repositories.Interfaces;
using Shop.Shared.Entities;
using Shop.Data.DataContext.Interfaces;

namespace Shop.Data.Repositories
{
    public class LocationRepository : IProductDetailsRepository<string>
    {
        IProductDetailsContext<string> _locationContext;

        public LocationRepository(IProductDetailsContext<string> context)
        {
            _locationContext = context;
        }

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

        public void DeleteById(int id)
        {
            _locationContext.DeleteById(id);
        }

        public string GetById(int id)
        {
            return _locationContext.GetById(id);
        }


    }
}
