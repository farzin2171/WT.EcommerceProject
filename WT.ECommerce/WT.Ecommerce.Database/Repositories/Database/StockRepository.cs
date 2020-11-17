using System.Threading.Tasks;
using WT.Ecommerce.Database.Repositories.Interfaces;
using WT.Ecommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace WT.Ecommerce.Database.Repositories.Database
{
    public class StockRepository : BaseRepository<Stock>, IStockRepository
    {
        public StockRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public  Task<Stock> GetByProductIdAsync(int productId)
        {
            return _dbContext.Stoks.SingleAsync(s => s.ProductId == productId);
        }
    }
}
