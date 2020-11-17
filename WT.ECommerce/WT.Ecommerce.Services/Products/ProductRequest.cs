namespace WT.Ecommerce.Services.Products
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public int Qty { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
