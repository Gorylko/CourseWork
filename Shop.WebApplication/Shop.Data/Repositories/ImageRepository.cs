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

        public void DeleteAllByProductId(int productId)
        {
            _imageContext.DeleteAllByProductId(productId);
        }

        public void DeleteAllByUserId(int userId)
        {
            _imageContext.DeleteAllByUserId(userId);
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Image> GetAll()
        {
            throw new NotImplementedException();
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

        public void Save(Image image, object owner)
        {
            _imageContext.Save(image, owner);
        }
    }
}
