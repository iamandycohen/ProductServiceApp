using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Data
{
    public class ProductDbInitializer : DropCreateDatabaseAlways<ProductDbContext>
    {

        protected override void Seed(ProductDbContext context)
        {
            IList<Product> defaultProducts = new List<Product>();
            IList<Category> defaultCategories = new List<Category>();

            defaultCategories.Add(new Category { Id = 1, Name = "Baby" });
            defaultCategories.Add(new Category { Id = 2, Name = "Toys" });

            defaultProducts.Add(new Product { ProductId = 5555, Name = "Stroller", CategoryId = 1, LastUpdated = new DateTime(2014, 5, 23), Price = 199.99, Sku = "AEX143" });
            defaultProducts.Add(new Product { ProductId = 5543, Name = "Optimus Prime", CategoryId = 2, LastUpdated = new DateTime(2014, 2, 1), Price = 13.37, Sku = "IOL123" });
            defaultProducts.Add(new Product { ProductId = 7563, Name = "Sega Genesis", CategoryId = 1, LastUpdated = new DateTime(1989, 4, 1), Price = 149.99, Sku = "XYZ904" });

            using (var transaction = context.Database.BeginTransaction())
            {
                foreach (var category in defaultCategories)
                {
                    context.Categories.Add(category);
                }

                foreach (var product in defaultProducts)
                {
                    context.Products.Add(product);
                }
            }


            base.Seed(context);
        }
    }
}
