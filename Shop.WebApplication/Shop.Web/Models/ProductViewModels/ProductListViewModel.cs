using Shop.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.Models.ProductViewModels
{
    public class ProductListViewModel
    {
        public IReadOnlyCollection<Product> Products { get; set; }
    }
}