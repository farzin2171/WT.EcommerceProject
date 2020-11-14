namespace WT.Ecommerce.Domain.Models
{
    public sealed class Stock:BaseEntity
    {
        public string Description { get; set; }
        public int Qty { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
