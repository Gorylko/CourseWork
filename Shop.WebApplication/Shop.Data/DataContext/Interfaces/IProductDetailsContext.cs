namespace Shop.Data.DataContext.Interfaces
{
    public interface IProductDetailsContext<T> : IDataContext<T>
    {
        bool IsExists(T obj);
    }
}
