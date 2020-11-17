using System.Collections.Generic;

namespace WT.Ecommerce.Domain.Models
{
    public class CustomerInformationQueryResult
    {
        public PaginationLinks Links { get; set; }
        public IReadOnlyList<CustomerInformation> results { get; set; }
    }

    public class ProductQueryResult
    {
        public PaginationLinks Links { get; set; }
        public IReadOnlyList<Product> results { get; set; }
    }
}
