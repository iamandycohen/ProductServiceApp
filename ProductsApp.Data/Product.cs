using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Data
{
    public class Product
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Sku { get; set; }
        [Required]
        public double Price { get; set; }

        public DateTime LastUpdated { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
