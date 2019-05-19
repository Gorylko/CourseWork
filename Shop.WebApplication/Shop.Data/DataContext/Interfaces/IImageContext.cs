using Shop.Shared.Entities;
using Shop.Shared.Entities.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.DataContext.Interfaces
{
    public interface IImageContext
    {
        Image GetById(int id);

        void Save(Image image, object owner);

        void DeleteAllByProductId(int productId);

        void DeleteAllByUserId(int userId);

        IReadOnlyCollection<Image> GetAllByProductId(int id);

        IReadOnlyCollection<Image> GetAllByUserId(int id);
    }
}
