using Shop.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        string GetCategoryString();

        Category GetById(int id);

        IReadOnlyCollection<Category> GetAll();

        void Save(Category category);
    }
}
