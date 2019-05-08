using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Shared.Entities.Images
{
    public class UserImage
    {
        public int UserId { get; set; }

        public Image Image { get; set; }
    }
}
