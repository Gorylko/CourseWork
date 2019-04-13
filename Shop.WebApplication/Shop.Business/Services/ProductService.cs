using Shop.Data.DataContext.Realization.MsSql;
using Shop.Data.Repositories;
using Shop.Shared.Entities;
using System.Collections.Generic;

namespace Shop.Business.Services
{
    public class ProductService
    {
        private ProductRepository _productRepository = new ProductRepository(new ProductContext());

        public IReadOnlyCollection<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public IReadOnlyCollection<Product> GetSearchList(string searchParameter, string searchQuery)
        {
            return _productRepository.GetAllByName(searchParameter, searchQuery);
        }

        public IReadOnlyCollection<Product> GetProductsByCategoryId(int categoryId)
        {
            return _productRepository.GetAllByCategoryId(categoryId);
        }

        public IReadOnlyCollection<Product> GetByUserId(int userId)
        {
            return _productRepository.GetByUserId(userId);
        }

        public Product GetProductById(int productId)
        {
            return _productRepository.GetById(productId);
        }

        public void DeleteById(int id)
        {
            _productRepository.DeleteById(id);
        }
        
        public void Save(Product product)
        {
            _productRepository.Save(product);
        }

    }
}
