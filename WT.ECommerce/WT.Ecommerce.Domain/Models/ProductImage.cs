namespace WT.Ecommerce.Domain.Models
{
    public class ProductImage:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
