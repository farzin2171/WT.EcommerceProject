using System;
using System.Collections.Generic;
using System.Text;

namespace WT.Ecommerce.Domain.Models
{
    public sealed class OrderStock
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int Qty { get; set; }
        public int StockId { get; set; }
        public Stock Stock { get; set; }
    }
}
