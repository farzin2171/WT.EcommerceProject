using System.Threading.Tasks;
using WT.Ecommerce.Database.Repositories.Interfaces;
using WT.Ecommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace WT.Ecommerce.Database.Repositories.Database
{
    public class CustomerInformationRepository : BaseRepository<CustomerInformation>, ICustomerInfoRepository
    {
        public CustomerInformationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Task<CustomerInformation> GetByRefIdAsync(string refId)
        {
            return  _dbContext.customerInformation.SingleAsync(c => c.RefrenceId == refId);
        }
    }
}
