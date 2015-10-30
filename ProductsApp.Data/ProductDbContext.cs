using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Data
{
    public class ProductDbContext : DbContext
    {

        public ProductDbContext() : base("ProductDbContext")
        {
            Database.SetInitializer<ProductDbContext>(new ProductDbInitializer());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
