using System.Collections.Generic;

namespace Shop.Data.DataContext.Interfaces
{
    public interface IProductDetailsContext<T> : IDataContext<T>
    {
        int GetIdByName(string name);
    }
}
