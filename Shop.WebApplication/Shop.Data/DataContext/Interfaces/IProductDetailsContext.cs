using System.Collections.Generic;

namespace Shop.Data.DataContext.Interfaces
{
    public interface IProductDetailsContext<T>
    {
        int GetIdByName(string name);

        IReadOnlyCollection<T> GetAll();
    }
}
