using System.Collections.Generic;
using System.Threading.Tasks;
using WT.Ecommerce.Database.Repositories.Interfaces;
using WT.Ecommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace WT.Ecommerce.Database.Repositories.Database
{
    public class ProductImageRepository : BaseRepository<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Task<ProductImage> GetProductImageByName(string name)
        {
            return _dbContext.productImages.SingleAsync(p => p.Name == name);
        }

        public async Task<IReadOnlyList<ProductImage>> GetProductImagesAsync(int productId)
        {
            return await _dbContext.productImages.Where(p => p.ProductId == productId).ToListAsync();
        }
    }
}
