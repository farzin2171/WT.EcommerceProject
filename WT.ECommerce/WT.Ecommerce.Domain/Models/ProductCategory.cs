using System.Collections.Generic;

namespace WT.Ecommerce.Domain.Models
{
    public sealed class ProductCategory:BaseEntity
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } 

    }
}
