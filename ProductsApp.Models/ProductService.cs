using ProductsApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Models
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
                Id = p.Id,
                Name = p.Name,
                Sku = p.Sku,
                Price = p.Price,
                LastUpdated = p.LastUpdated,
                Category = p.Category.Name
            });
        }

        public IProductDto GetProduct(int id)
        {
            return GetProducts()
                .FirstOrDefault(p => p.Id == id);
        }


        public bool AddProduct(IProductDto product)
        {

            var  newProduct = new Product
            {
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
