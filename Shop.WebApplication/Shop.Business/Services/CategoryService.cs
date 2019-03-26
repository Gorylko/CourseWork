using Shop.Data.Repositories;
using Shop.Data.DataContext.Realization.MsSql;
using System.Collections.Generic;
using Shop.Shared.Entities;

namespace Shop.Business.Services
{
    public class CategoryService
    {
        private CategoryRepository _categoryRepository = new CategoryRepository(new CategoryContext());
        
        public string GetCategoryString()
        {
            return _categoryRepository.GetAllString() + "Чтобы вернуться назад - пиши /r"; 
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public IReadOnlyCollection<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }
        //еще можно реализовать методы, но они пока не нужны
    }
}
