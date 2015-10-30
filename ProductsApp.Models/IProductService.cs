using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Models
{
    public interface IProductService
    {
        IQueryable<IProductDto> GetProducts();
        IProductDto GetProduct(int id);
        bool AddProduct(IProductDto product);
    }
}
