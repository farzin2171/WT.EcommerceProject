using System.Collections.Generic;
using WT.Ecommerce.Domain.Models;

namespace WT.Ecommerce.Services.Products
{
    public class ProductQueryResult
    {
        public PaginationLinks Links { get; set; }
        public IEnumerable<ProductResponse> results { get; set; }
    }
}
