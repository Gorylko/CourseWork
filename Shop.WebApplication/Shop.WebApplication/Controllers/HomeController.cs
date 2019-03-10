using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Business.Services;
using Shop.Shared.Entities;

namespace Shop.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        ProductService _productService = new ProductService();

        public ActionResult Index()
        {
            ViewBag.Products = _productService.GetAll();
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.ProductId = id;
            return View();
        }

        //[HttpPost]
        //public string Buy(Purchase purchase)
        //{
        //    purchase.Date = DateTime.Now;
        //    // добавляем информацию о покупке в базу данных
        //    db.Purchases.Add(purchase);
        //    // сохраняем в бд все изменения
        //    db.SaveChanges();
        //    return "Спасибо," + purchase.Person + ", за покупку!";
        //}
    }
}