using System.Collections.Generic;

namespace WT.Ecommerce.Domain.Models
{
    public class CustomerInformationQueryResult
    {
        public PaginationLinks Links { get; set; }
        public IReadOnlyList<CustomerInformation> results { get; set; }
    }
}
