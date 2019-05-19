using Shop.Shared.Entities.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories.Interfaces
{
    public interface IImageRepository
    {
        IReadOnlyCollection<Image> GetAllByProductId(int id);

        IReadOnlyCollection<Image> GetAllByUserId(int id);

        void Save(Image image, object owner);

        IReadOnlyCollection<Image> GetAll();

        void DeleteAllByProductId(int productId);

        void DeleteAllByUserId(int userId);

        Image GetById(int id);

        void DeleteById(int id);
    }
}
