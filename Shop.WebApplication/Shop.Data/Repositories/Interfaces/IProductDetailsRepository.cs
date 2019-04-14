using Shop.Data.DataContext.Interfaces;

namespace Shop.Data.Repositories.Interfaces
{
    public interface IProductDetailsRepository<T> : IDataContext<T>
    {
        int GetIdByName(string name);
    }

}
