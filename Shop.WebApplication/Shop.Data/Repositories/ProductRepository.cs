using Shop.Data.DataContext.Interfaces;
using Shop.Data.Repositories.Interfaces;
using Shop.Shared.Entities;
using System.Collections.Generic;

namespace Shop.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository(IProductContext productContext)
        {
            this._productContext = productContext;
        }

        private IProductContext _productContext;

        public IReadOnlyCollection<Product> GetAll()
        {
            return _productContext.GetAll();
        }

        public IReadOnlyCollection<Product> GetByUserId(int userId)
        {
            return _productContext.GetByUserId(userId);
        }

        public void DeleteById(int id)
        {
            _productContext.DeleteById(id);
        }

        public Product GetById(int id)
        {
            return _productContext.GetById(id);
        }

        public IReadOnlyCollection<Product> GetAllByCategoryId(int id)
        {
            return _productContext.GetByCategoryId(id);
        }

        public IReadOnlyCollection<Product> GetAllByName(string searchParameter, string searchQuery)
        {
            return _productContext.GetAllByName(searchParameter, searchQuery);
        }

        public void Save(Product product)
        {
            _productContext.Save(product);
        }
    }
}
