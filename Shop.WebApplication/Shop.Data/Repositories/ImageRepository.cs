using Shop.Data.DataContext.Interfaces;
using Shop.Data.Repositories.Interfaces;
using Shop.Shared.Entities.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private IImageContext _imageContext;

        public ImageRepository(IImageContext context)
        {
            _imageContext = context;
        }

        public IReadOnlyCollection<Image> GetAllByProductId(int id)
        {
            return _imageContext.GetAllByProductId(id);
        }

        public IReadOnlyCollection<Image> GetAllByUserId(int id)
        {
            return _imageContext.GetAllByUserId(id);
        }

        public Image GetById(int id)
        {
            return _imageContext.GetById(id);
        }
    }
}
