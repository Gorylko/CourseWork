using Shop.Data.Repositories;
using Shop.Data.DataContext.Realization.MsSql;

namespace Shop.Business.Services
{
    public class CategoryService
    {
        private CategoryRepository _categoryRepository = new CategoryRepository(new CategoryContext());
        
        public string GetCategoryString()
        {
            return _categoryRepository.GetAllString() + "Чтобы вернуться назад - пиши /r"; 
        }

        public string GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }
        //еще можно реализовать методы, но они пока не нужны
    }
}
