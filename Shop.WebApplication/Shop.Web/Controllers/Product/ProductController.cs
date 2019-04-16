using Shop.Business.Services;
using Shop.Shared.Entities;
using Shop.Shared.Entities.Authorize;
using Shop.Web.Attributes;
using Shop.Web.Models.ProductViewModels;
using System;
using System.Web.Mvc;

namespace Shop.Web.Controllers.Product
{
    public class ProductController : Controller
    {
        private ProductService _productService = new ProductService();
        private PurchaseService _purchaseService = new PurchaseService();
        private CategoryService _categoryService = new CategoryService();
        private UserService _userService = new UserService();
        private StateService _stateService = new StateService();
        private LocationService _locationService = new LocationService();

        [User]
        public ActionResult AddNewProduct()
        {
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.States = _stateService.GetAll();
            return View(new ProductViewModel());
        }

        [User]
        [HttpPost]
        public ActionResult AddNewProduct(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _categoryService.GetAll();
                ViewBag.States = _stateService.GetAll();
                return View(model);
            }
            var user = User as UserPrinciple;
            if (!_locationService.IsExists(model.LocationOfProduct))
            {
                _locationService.Save(model.LocationOfProduct);
            }
            _productService.Save(new Shared.Entities.Product
            {
                Name = model.Name,
                Category = new Category
                {
                    Id = model.Category.Id,
                    Name = model.Category.Name
                },
                CreationDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Description = model.Description,
                LocationOfProduct = model.LocationOfProduct,
                Price = model.Price,
                State = new State
                {
                    Id = model.State.Id,
                },
                Author = new User
                {
                    Id = _userService.GetByLogin(user.Name).Id
                }
            });
            ViewBag.Message = $"Товар \"{model.Name}\" добавлен в каталог и будет отображаться у всех дользователей!";
            return View("~/Views/Shared/Notification.cshtml");
        }

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
