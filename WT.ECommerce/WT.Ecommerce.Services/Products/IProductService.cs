using System.Threading.Tasks;
using WT.Ecommerce.Domain.Models;

namespace WT.Ecommerce.Services.Products
{
    public interface IProductService
    {
        Task<ProductQueryResult> GetPaged(int take, int skip,int? categoryId);
        Task<Domain.Models.Product> Create(ProductViewModel input);
        Task<ProductImage> AddImage(string name, string description,int productId);
        Task RemoveImage(string name);
    }
}
