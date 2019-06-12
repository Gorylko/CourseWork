using Shop.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Services.Interfaces
{
    public interface IProductService
    {
        IReadOnlyCollection<Product> GetAll();

        void Archive(int id);

        IReadOnlyCollection<Product> GetSearchList(string searchParameter, string searchQuery);

        IReadOnlyCollection<Product> GetProductsByCategoryId(int categoryId);

        IReadOnlyCollection<Product> GetByUserId(int userId);

        Product GetProductById(int productId);

        void DeleteById(int id);

        void Save(Product product);

        void Edit(Product editedProduct);

        void ArchiveAllByUserId(int userId);

        IReadOnlyCollection<Product> GetAllWithFilters(IEnumerable<Predicate<Product>> filters);

        IReadOnlyCollection<Product> GetAllByFilterParameters(ProductFilterParameters parameters);

        int GetIdByProduct(Product product);
    }
}
