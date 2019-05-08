using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Shared.Entities.Images
{
    public class ProductImage
    {
        public int ProductId { get; set; }

        public Image Image { get; set; }
    }
}
