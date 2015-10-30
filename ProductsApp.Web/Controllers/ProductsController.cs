using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ProductsApp.Web.Controllers
{
    public class ProductsController : ApiController
    {

        private IProductService ProductService { get; set; }


        public ProductsController() : this(new ProductService()) { }

        public ProductsController(IProductService productService)
        {
            ProductService = productService;
        }

        // GET: api/Products
        public IQueryable<IProductDto> Get()
        {
            return ProductService.GetProducts();
        }

        // GET: api/Products/5
        [ResponseType(typeof(IProductDto))]
        public IHttpActionResult Get(int id)
        {
            var product = ProductService.GetProduct(id);
            if (product == null) {
                return NotFound();
            }

            return Ok(product);
        }

    }
}
