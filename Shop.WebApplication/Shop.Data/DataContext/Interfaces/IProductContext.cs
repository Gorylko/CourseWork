using Shop.Shared.Entities;
using System.Collections.Generic;

namespace Shop.Data.DataContext.Interfaces
{
    public interface IProductContext : IDataContext<Product>
    {
        IReadOnlyCollection<Product> GetByCategoryId(int categoryId);

        IReadOnlyCollection<Product> GetByUserId(int userId);

        IReadOnlyCollection<Product> GetAllByName(string searchParameter, string searchQuery);

        int GetIdByProduct(Product product);

        void Edit(Product product);

        void Archive(int id);
    }
}
