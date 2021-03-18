using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Business.Services;
using Shop.Shared.Entities;

namespace Shop.Business.Test.ServicesTests
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void GetProductById_SeledkaReturned()
        {
            int idOfTestProduct = 1;
            var productService = new ProductService();
            var product = productService.GetProductById(idOfTestProduct);
            var expectedProduct = new Product
            {
                Id = 1,
                Name = "СЯЛЁДКА",
                Description = "Пожилая сельдь, с озер украины прямо к вам на стол",
                Category = new Category
                {
                    Id = 1,
                    Name = "Food"
                }
            };
            Assert.AreNotEqual(product, null);
            Assert.AreEqual(product.Id, expectedProduct.Id);
            Assert.AreEqual(product.Name, expectedProduct.Name);
            Assert.AreEqual(product.Description, expectedProduct.Description);
            Assert.AreEqual(product.Category.Name, expectedProduct.Category.Name);
        }
    }
}
