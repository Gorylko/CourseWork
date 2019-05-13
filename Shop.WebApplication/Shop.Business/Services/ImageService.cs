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

        public Image GetById(int id)
        {
            return _imageRepository.GetById(id);
        }
    }
}
