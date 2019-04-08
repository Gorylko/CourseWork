using System.Collections.Generic;
using Shop.Shared.Entities;

namespace Shop.Data.DataContext.Interfaces
{
    public interface IProductContext : IDataContext<Product>
    {
        IReadOnlyCollection<Product> GetByCategoryId(int categoryId);

        IReadOnlyCollection<Product> GetByUserId(int userId);

        IReadOnlyCollection<Product> GetAllByName(string searchParameter, string searchQuery);
    }
}
