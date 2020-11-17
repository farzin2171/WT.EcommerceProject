using System.Collections.Generic;
using System.Threading.Tasks;
using WT.Ecommerce.Domain.Models;

namespace WT.Ecommerce.Database.Repositories.Interfaces
{
    public interface IProductImageRepository: IDatabaseRepository<ProductImage>
    {
        Task<IReadOnlyList<ProductImage>> GetProductImagesAsync(int productId);
        Task<ProductImage> GetProductImageByName(string name);
    }
}
