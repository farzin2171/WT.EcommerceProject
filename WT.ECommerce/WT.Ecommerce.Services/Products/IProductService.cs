using System.Threading.Tasks;
using WT.Ecommerce.Domain.Models;

namespace WT.Ecommerce.Services.Products
{
    public interface IProductService
    {
        Task<ProductQueryResult> GetPaged(int limit, int skip,string name,int? categoryId);
        Task<ProductResponse> Create(ProductRequest input);
        Task<ProductImage> AddImage(string name, string description,int productId);
        Task RemoveImage(string name);
    }
}
