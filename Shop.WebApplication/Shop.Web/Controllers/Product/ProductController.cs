using Shop.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Web.Models.ProductViewModels;

namespace Shop.Web.Controllers.Product
{
    public class ProductController : Controller
    {
        ProductService _productService = new ProductService();

        public ActionResult GetProductList()
        {
            ViewBag.Products = _productService.GetAll();
            return View();
        }

        public ActionResult GetProductByCategoryId(int categoryId)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = _productService.GetProductsByCategoryId(categoryId)
            };
            return View();
        }

        public ActionResult ShowInfoAboutProduct(int id)
        {
            //HttpContext.Session.Set
            ViewBag.Product = _productService.GetProductById(id);
            return View();
        }

        public ActionResult BuyProduct(int id)
        {

        }
    }
}
