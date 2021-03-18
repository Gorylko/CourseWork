using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop.Shared.Entities.Images;

namespace Shop.Web.Models
{
    public class ImageViewModel
    {
        public IReadOnlyCollection<Image> Images { get; set; }
    }
}