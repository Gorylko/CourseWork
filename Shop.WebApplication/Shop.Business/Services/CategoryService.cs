using Shop.Business.Services.Interfaces;
using Shop.Data.DataContext.Realization.MsSql;
using Shop.Data.Repositories;
using Shop.Shared.Entities;
using System.Collections.Generic;

namespace Shop.Business.Services
{
    public class CategoryService : ICategoryService
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

        public void Save(Category category)
        {
            _categoryRepository.Save(category);
        }
    }
}
