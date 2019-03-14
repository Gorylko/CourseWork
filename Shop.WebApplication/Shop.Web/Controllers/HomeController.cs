using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Web.Models;

namespace Shop.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Buy(int productId)
        {
            ViewBag.ProductId = productId;
            return View();
        }

        [HttpPost]
        public ActionResult Buy(Purchase purchase)
        {
            return View();
        }
    }
}