using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Collections.Generic;

namespace ProductsApp.Models.Tests
{
    [TestClass]
    public class ProductServiceTests
    {

        public IProductService ProductService { get; set; }

        [TestInitialize]
        public void Init()
        {
            var productService = new Moq.Mock<IProductService>();
            var data = new List<IProductDto>
            {
                new ProductDto { Id = 5555, Name = "Stroller", Category = "Baby", LastUpdated = DateTime.UtcNow, Price = 199.99, Sku = "AEX143" },
                new ProductDto { Id = 5543, Name = "Optimus Prime", Category = "Toys", LastUpdated = DateTime.UtcNow, Price = 13.37, Sku = "IOL123" },
                new ProductDto { Id = 7563, Name = "Sega Genesis", Category = "Toys", LastUpdated = DateTime.UtcNow, Price = 149.99, Sku = "XYZ904" }
            };

            productService.Setup(m => m.GetProducts()).Returns(data.AsQueryable());
            productService.Setup(m => m.GetProduct(It.IsAny<int>())).Returns(data.First());
            productService.Setup(m => m.AddProduct(It.IsAny<IProductDto>())).Returns(
                (IProductDto product) =>
                {
                    product.Id = data.Last().Id + 1;
                    product.LastUpdated = DateTime.UtcNow;
                    data.Add(product);

                    return true;
                });

            ProductService = productService.Object;
        }

        [TestMethod]
        public void GetProductsTest()
        {
            // arrange


            // act
            var products = ProductService.GetProducts();

            // assert
            Assert.IsNotNull(products);
            Assert.IsInstanceOfType(products, typeof(IQueryable<IProductDto>));
            Assert.IsTrue(products.First().Id == 5555);

        }

        [TestMethod]
        public void GetProductTest()
        {
            // arrange


            // act
            var product = ProductService.GetProduct(5555);

            // assert
            Assert.IsNotNull(product);
            Assert.IsInstanceOfType(product, typeof(IProductDto));
            Assert.IsTrue(product.Id == 5555);
        }

        [TestMethod]
        public void AddProductTest()
        {
            // arrange
            var newProduct = new ProductDto
            {
                Name = "Teddy Ruxpin",
                Category = "Toys",
                Price = 99.99,
                Sku = "QWERTY"
            };

            // act
            var success = ProductService.AddProduct(newProduct);

            // assert
            Assert.IsTrue(success);
            Assert.IsInstanceOfType(success, typeof(bool));
            Assert.AreEqual(newProduct.Id, 7564);
            Assert.AreEqual(newProduct.Sku, "QWERTY");
            Assert.AreEqual(newProduct.Name, "Teddy Ruxpin");
        }

    }
}
