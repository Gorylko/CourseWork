using Shop.Data.DataContext.Interfaces;
using Shop.Data.Repositories.Interfaces;
using Shop.Shared.Entities;
using System.Collections.Generic;

namespace Shop.Data.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        ICategoryContext _categoryContext;

        public CategoryRepository(ICategoryContext categoryContext)
        {
            this._categoryContext = categoryContext;
        }

        public string GetAllString()
        {
            return _categoryContext.GetAllString();
        }

        public IReadOnlyCollection<Category> GetAll()
        {
            return _categoryContext.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryContext.GetById(id);
        }

        public void DeleteById(int id)
        {
            _categoryContext.DeleteById(id);
        }

        public void Save(Category category)
        {
            _categoryContext.Save(category);
        }
    }
}
