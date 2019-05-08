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
        Image GetById(int id);

        IReadOnlyCollection<Image> GetAllByProductId(int id);

        IReadOnlyCollection<Image> GetAllByUserId(int id);
    }
}
