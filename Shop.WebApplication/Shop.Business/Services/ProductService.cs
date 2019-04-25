using Shop.Data.DataContext.Realization.MsSql;
using Shop.Data.Repositories;
using Shop.Shared.Entities;
using System;
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

        public void Edit(Product editedProduct)
        {
            _productRepository.Edit(editedProduct);
        }

        public IReadOnlyCollection<Product> GetAllWithFilters(IEnumerable<Predicate<Product>> filters)
        {
            List<Product> products = (List<Product>)_productRepository.GetAll();
            List<Product> returnList = new List<Product>();
            bool IsCorrect;
            for (int i = 0 ; i < products.Count; i++)
            {
                IsCorrect = true;
                foreach(var filter in filters)
                {
                    if (!filter(products[i]))
                    {
                        IsCorrect = false;
                    }
                }
                if (IsCorrect)
                {
                    returnList.Add(products[i]);
                }
            }
            return returnList;
        }

        public IReadOnlyCollection<Product> GetAllByFilterParameters(ProductFilterParameters parameters)
        {
            List<Predicate<Product>> filters = new List<Predicate<Product>>();
            if (parameters.MaxPrice != default(decimal))
            {
                filters.Add(product => product.Price <= parameters.MaxPrice);
            }
            if (parameters.MinPrice != default(decimal))
            {
                filters.Add(product => product.Price >= parameters.MinPrice);
            }
            if (parameters.Name != default(string))
            {
                filters.Add(product => product.Name.IndexOf(parameters.Name, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            if (parameters.State.Id != default(int))
            {
                filters.Add(product => product.State.Id == parameters.State.Id);
            }
            if (parameters.Category.Id != default(int))
            {
                filters.Add(product => product.Category.Id == parameters.Category.Id);
            }
            if(filters == null)
            {
                return GetAll();
            }
            return GetAllWithFilters(filters);
        }

    }
}
