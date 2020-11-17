using WT.Ecommerce.Domain.Models;

namespace WT.Ecommerce.Database.Specifications
{
    public sealed class LatestProductSpecification: BaseSpecification<Product>
    {
        public LatestProductSpecification(string name,int? CategoryId=null, int? limit = null, int? skip = null)
        {
            AddCriteria(p => (string.IsNullOrEmpty(name) || p.Name.Contains(name)) &&
                             (CategoryId == null || p.ProductCategoryId == CategoryId));
            AddInclude(p => p.ProductCategory);

            if (skip != null || limit != null)
            {
                ApplyPaging(skip.GetValueOrDefault(), limit.GetValueOrDefault());
            }

            ApplyOrderByDescending(p => p.Id);

        }
    }
}
