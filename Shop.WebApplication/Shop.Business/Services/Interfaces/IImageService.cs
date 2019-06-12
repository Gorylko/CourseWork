using Shop.Shared.Entities.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Services.Interfaces
{
    public interface IImageService
    {
        IReadOnlyCollection<Image> GetAllByProductId(int id);

        IReadOnlyCollection<Image> GetAllByUserId(int id);

        void DeleteAllByUserId(int userId);

        void DeleteAllByProductId(int productId);

        Image GetById(int id);

        void Save(Image image, object owner);

        void SaveAll(IEnumerable<Image> images, object owner);
    }
}
