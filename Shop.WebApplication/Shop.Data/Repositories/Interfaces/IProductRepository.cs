using Shop.Shared.Entities;
using System.Collections.Generic;

namespace Shop.Data.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IReadOnlyCollection<Product> GetAllByCategoryId(int categoryId);

        IReadOnlyCollection<Product> GetByUserId(int userId);

        IReadOnlyCollection<Product> GetAllByName(string searchParameter, string searchQuery);

        void Edit(Product editedProduct);
    }
}
