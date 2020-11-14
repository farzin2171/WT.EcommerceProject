using System.Threading.Tasks;
using WT.Ecommerce.Domain.Models;

namespace WT.Ecommerce.Services.Customers
{
    public interface ICustomerInformationService
    {
        Task<CustomerInformationQueryResult> GetPaged(int take, int skip);
        Task<CustomerInformation> Create(CustomerInformationViewModel customerInformationViewModel);
    }
}
