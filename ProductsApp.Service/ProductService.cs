using ProductsApp.Data;
using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Service
{
    public class ProductService : IProductService
    {

        private ProductDbContext ProductDbContext { get; set; }

        public ProductService()
        {
            ProductDbContext = new ProductDbContext();
        }

        public IQueryable<IProductDto> GetProducts()
        {
            return ProductDbContext.Products.Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Sku = p.Sku,
                Price = p.Price,
                LastUpdated = p.LastUpdated,
                Category = p.Category.Name
            });
        }

        public IProductDto GetProduct(int productId)
        {
            var products = GetProducts();
            var product = products.FirstOrDefault(p => p.ProductId == productId);
            return product;
        }


        public bool AddProduct(IProductDto product)
        {

            var productId = GetProducts().Select(e => e.ProductId).Max() + 1;
            var  newProduct = new Product
            {
                ProductId = productId,
                LastUpdated = DateTime.UtcNow,
                Name = product.Name,
                Price = product.Price,
                Sku = product.Sku
            };

            if  (!string.IsNullOrEmpty(product.Category)) 
            {
                var category = ProductDbContext.Categories.FirstOrDefault(e => e.Name.Equals(product.Category));
                if (category != null) 
                {
                    newProduct.CategoryId = category.Id;
                }
            }

            var addedProduct = ProductDbContext.Products.Add(newProduct);

            if (addedProduct != null && addedProduct.Id != 0) 
            {
                return ProductDbContext.SaveChanges() == 1;
            }

            return false;
        }
    }
}
