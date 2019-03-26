using Shop.Shared.Entities;

namespace Shop.Data.DataContext.Interfaces
{
    public interface ICategoryContext : IDataContext<Category>
    {
        string GetAllString();
    }
}
