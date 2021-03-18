using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Shared.Entities;

namespace Shop.Data.DataContext.Interfaces
{
    public interface ILocationContext<TLocation> : IDataContext<TLocation>
    {
        int GetId(TLocation location);

        //IReadOnlyCollection<TLocation> GetAllLocations();

        //IReadOnlyCollection<TCountry> GetAllContries();

        //IReadOnlyCollection<TCity> GetAllCities();

        //IReadOnlyCollection<TAddress> GetAllAddresses();

        //TLocation GetLocationById(int id);

        //TCountry GetCountryById(int id);

        //TCity GetCityById(int id);

        //TCity GetAddressById(int id);
    }
}
