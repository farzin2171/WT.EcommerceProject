using System.Threading.Tasks;
using WT.Ecommerce.Domain.Models;

namespace WT.Ecommerce.Database.Repositories.Interfaces
{
    public interface IStockRepository : IDatabaseRepository<Stock> 
    {
        Task<Stock> GetByProductIdAsync(int productId);
    }
    
}
