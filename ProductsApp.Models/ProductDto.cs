using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Models
{
    [DataContract]
    public class ProductDto : IProductDto
    {
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public string Sku { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public DateTime LastUpdated { get; set; }
        [DataMember]
        public double Price { get; set; }
    }
}
