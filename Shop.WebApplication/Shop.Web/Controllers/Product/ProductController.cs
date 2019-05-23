using Shop.Business.Services;
using Shop.Shared.Entities;
using Shop.Shared.Entities.Images;
using ProductEntity = Shop.Shared.Entities.Product;
using Shop.Shared.Entities.Authorize;
using Shop.Web.Attributes;
using Shop.Web.Models;
using Shop.Web.Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web;

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
        private ImageService _imageService = new ImageService();


        [User]
        public ActionResult AddNewProduct()
        {
            return View(new ProductViewModel()
            {
                Categories = _categoryService.GetAll(),
                States = _stateService.GetAll()
            });
        }

        [User]
        [HttpPost]
        public ActionResult AddNewProduct(ProductViewModel model, IEnumerable<HttpPostedFileBase> images = null)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _categoryService.GetAll();
                ViewBag.States = _stateService.GetAll();
                return View(model);
            }

            var user = User as UserPrinciple;
            _locationService.Save(model.Location);
            model.Location.Id = _locationService.GetId(model.Location);
            var imagesList = new List<Image>();

            if (images != null)
            {
                foreach (var image in images)
                {
                    imagesList.Add(new Image
                    {
                        Data = GetImageData(image),
                        Extension = image.ContentType
                    });
                }
            }

            var product = new ProductEntity
            {
                Name = model.Name,
                Category = model.Category,
                CreationDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Description = model.Description,
                Location = model.Location,
                Price = model.Price,
                State = new State
                {
                    Id = model.State.Id,
                },
                Author = new User
                {
                    Id = user.UserId
                },
                Images = imagesList
            };

            _productService.Save(product);
            product.Id = _productService.GetIdByProduct(product);
            if (images != null)
            {
                _imageService.SaveAll(product.Images, product);
            }
            ViewBag.Message = $"Товар \"{model.Name}\" добавлен в каталог и будет отображаться у всех дользователей!";
            return View("~/Views/Shared/Notification.cshtml");
        }

        public byte[] GetImageData(HttpPostedFileBase image)
        {
            var returnData = new byte[image.ContentLength];
            image.InputStream.Read(returnData, 0, image.ContentLength);
            return returnData;
        }

        public ActionResult ShowProductList()
        {
            ViewBag.Message = "Список всех товаров";
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(model);
        }

        public ActionResult ShowByUserId(int id)
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetByUserId(id)
            };
            ViewBag.Message = $"Товары пользователя {_userService.GetById(id).Login}";
            return View("~/Views/Product/ShowProductList.cshtml", model);
        }

        public ActionResult ShowProductInfo(int id)
        {
            ViewBag.Product = _productService.GetProductById(id);
            return View();
        }

        [User]
        [HttpGet]
        public ActionResult BuyProduct(int id)
        {
            return View(new PurchaseViewModel() { ProductId = id });
        }

        [User]
        [HttpPost]
        public ActionResult BuyProduct(PurchaseViewModel model)
        {
            var user = User as UserPrinciple;
            var product = _productService.GetProductById(model.ProductId);
            _locationService.Save(model.Location);
            var purchase = new Purchase
            {
                Seller = product.Author,
                Customer = _userService.GetByLogin(user.Name),
                Product = product,
                Location = new Location
                {
                    Id = _locationService.GetId(model.Location),
                    Address = model.Location.Address,
                    City = model.Location.City,
                    Country = model.Location.Country
                },
                Date = DateTime.Now
            };
            _purchaseService.Save(purchase);
            _productService.Archive(purchase.Product.Id);
            return View("~/Views/Product/ShowPurchaseInfo.cshtml", new PurchaseViewModel
            {
                Date = purchase.Date,
                Customer = purchase.Customer,
                Seller = purchase.Seller,
                Location = purchase.Location,
                ProductId = purchase.Product.Id,
            });
        }


        public ActionResult OpenCategoryMenu()
        {
            ViewBag.Сategories = _categoryService.GetAll();
            return View();
        }

        public ActionResult ShowProductsByCategory(int categoryId)
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetProductsByCategoryId(categoryId)
            };
            return View("~/Views/Product/ShowProductList.cshtml", model);
        }

        [User]
        public ActionResult Delete(int id)
        {
            _imageService.DeleteAllByProductId(id);
            _productService.DeleteById(id);
            ViewBag.Message = $"Товар \"{_productService.GetProductById(id).Name}\" удален успешно!";
            return View("~/Views/Shared/Notification.cshtml");
        }

        [User]
        public ActionResult EditProduct(int id)
        {
            var user = User as UserPrinciple;
            var product = _productService.GetProductById(id);

            if (product.Author.Id != user.UserId)
            {
                ViewBag.ErrorText = "Данный товар вам не принадлежит!";
                return View("~/Shared/Error.cshtml");
            }

            return View(new EditProductViewModel
            {
                Id = id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Categories = _categoryService.GetAll(),
                Author = product.Author,
                Price = product.Price,
                State = product.State,
                States = _stateService.GetAll(),
                Location = product.Location
            });
        }

        [User]
        [HttpPost]
        public ActionResult EditProduct(EditProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _locationService.Save(model.Location);
            _productService.Edit(new ProductEntity
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Location = model.Location,
                LastModifiedDate = DateTime.Now,
                State = model.State,
                Category = model.Category,
                Author = model.Author
            });
            ViewBag.Message = $"Товар \"{model.Name}\" изменён успешно!";
            return View("~/Views/Shared/Notification.cshtml");
        }

        public ActionResult ShowSearchList()
        {
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.States = _stateService.GetAll();
            return View(new SearchViewModel() { Products = (List<ProductEntity>)_productService.GetAll() });
        }

        [HttpPost]
        public ActionResult ShowSearchList(SearchViewModel model)
        {
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.States = _stateService.GetAll();

            model.Products = (List<ProductEntity>)_productService.GetAllByFilterParameters(new ProductFilterParameters
            {
                Category = model.Category,
                MaxPrice = model.MaxPrice,
                MinPrice = model.MinPrice,
                Name = model.Name,
                State = model.State,
            });
            return View(model);
        }
    }
}
