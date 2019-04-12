using Shop.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Web.Models.ProductViewModels;
using Shop.Shared.Entities;
using Shop.Shared.Entities.Authorize;
using Shop.Web.Attributes;

namespace Shop.Web.Controllers.Product
{
    public class ProductController : Controller
    {
        ProductService _productService = new ProductService();
        PurchaseService _purchaseService = new PurchaseService();
        CategoryService _categoryService = new CategoryService();
        UserService _userService = new UserService();

        public ActionResult ShowProductList()
        {
            ViewBag.Products = _productService.GetAll();
            return View();
        }

        public ActionResult ShowByUserId(int userId)
        {
            ViewBag.Products = _productService.GetByUserId(userId);
            return View("~/Views/Product/ShowProductList.cshtml");
        }

        public ActionResult ShowProductInfo(int id)
        {
            ViewBag.Product = _productService.GetProductById(id);
            return View();
        }

        [HttpGet]
        public ActionResult BuyProduct(int id)
        {
            ViewBag.Product = _productService.GetProductById(id);
            return View();
        }

        [HttpPost]
        public ActionResult BuyProduct(string address, int productId)
        {
            var user = User as UserPrinciple;
            Shared.Entities.Product product = _productService.GetProductById(productId);
            Purchase purchase = new Purchase
            {
                Seller = product.Author,
                Customer = _userService.GetByLogin(user.Name),
                Product = product,
                Address = address,
                Date = DateTime.Now
            };
            _purchaseService.Save(purchase);
            _productService.DeleteById(purchase.Product.Id);
            ViewBag.Purchase = purchase;
            return View("~/Views/Product/ShowPurchaseInfo.cshtml");
        }

        
        public ActionResult OpenCategoryMenu()
        {
            ViewBag.Сategories = _categoryService.GetAll();
            return View();
        }

        public ActionResult ShowProductsByCategory(int categoryId)
        {
            ViewBag.Products = _productService.GetProductsByCategoryId(categoryId);
            return View("~/Views/Product/ShowProductList.cshtml"); //изменить 
        }
    }
}
