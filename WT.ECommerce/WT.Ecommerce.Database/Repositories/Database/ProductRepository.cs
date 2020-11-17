using WT.Ecommerce.Database.Repositories.Interfaces;
using WT.Ecommerce.Domain.Models;

namespace WT.Ecommerce.Database.Repositories.Database
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
