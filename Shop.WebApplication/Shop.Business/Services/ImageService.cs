using Shop.Data.DataContext.Realization.MsSql;
using Shop.Data.Repositories;
using Shop.Shared.Entities.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Services
{
    public class ImageService
    {
        private ImageRepository _imageRepository = new ImageRepository(new ImageContext());

        public IReadOnlyCollection<Image> GetAllByProductId(int id)
        {
            return _imageRepository.GetAllByProductId(id);
        }

        public IReadOnlyCollection<Image> GetAllByUserId(int id)
        {
            return _imageRepository.GetAllByUserId(id);
        }

        public void DeleteAllByUserId(int userId)
        {
            _imageRepository.DeleteAllByUserId(userId);
        }

        public void DeleteAllByProductId(int productId)
        {
            _imageRepository.DeleteAllByProductId(productId);
        }

        public Image GetById(int id)
        {
            return _imageRepository.GetById(id);
        }

        public void Save(Image image, object owner)
        {
            _imageRepository.Save(image, owner);
        }

        public void SaveAll(IEnumerable<Image> images, object owner)
        {
            foreach(var image in images)
            {
                Save(image, owner);
            }
        }
    }
}
