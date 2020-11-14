namespace WT.Ecommerce.Domain.Models
{
    public class PaginationLinks
    {
        public string Self { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Prev { get; set; }
        public string Next { get; set; }
        public int RecordCount { get; set; }
        public int PageCount { get; set; }

    }
}
