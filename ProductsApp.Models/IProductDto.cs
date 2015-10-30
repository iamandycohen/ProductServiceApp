using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Models
{
    public interface IProductDto
    {
        int ProductId { get; set; }
        string Sku { get; set; }
        string Name { get; set; }
        string Category { get; set; }
        double Price { get; set; }
        DateTime LastUpdated { get; set; }
    }
}
