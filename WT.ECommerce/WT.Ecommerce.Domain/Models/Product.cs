using System.Collections.Generic;

namespace WT.Ecommerce.Domain.Models
{
    public sealed class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public int ProductCategoryId { get; set; }
        public ICollection<Stock> Stocks { get; set; }
    }
}
