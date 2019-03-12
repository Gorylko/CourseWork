using Shop.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.WebApplication.Models.ProductViewModels;

namespace Shop.WebApplication.Controllers.Product
{
    public class ProductController : Controller
    {
        ProductService _productService = new ProductService();

        public ActionResult GetProductList()
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View("ProductList", model);
        }

        public ActionResult GetProductByCategoryId(int categoryId)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = _productService.GetProductsByCategoryId(categoryId)
            };
            return View();
        }
    }
}
