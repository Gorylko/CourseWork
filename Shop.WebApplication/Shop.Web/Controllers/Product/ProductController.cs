﻿using Shop.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Web.Models.ProductViewModels;
using Shop.Shared.Entities;

namespace Shop.Web.Controllers.Product
{
    public class ProductController : Controller
    {
        ProductService _productService = new ProductService();

        PurchaseService _purchaseService = new PurchaseService();

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
        public void BuyProduct(string address, int productId)
        {
            Shared.Entities.Product product = _productService.GetProductById(productId);
            Purchase purchase = new Purchase
            {
                Seller = product.Author,
                Customer = (User)Session["User"],
                Product = product,
                Address = address,
                Date = DateTime.Now
            };
            _purchaseService.Save(purchase);
            _productService.DeleteById(purchase.Product.Id);
        }
    }
}
