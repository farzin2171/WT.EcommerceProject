using System;
using System.Threading.Tasks;
using WT.Ecommerce.Database.Repositories.Interfaces;
using WT.Ecommerce.Domain.Models;

namespace WT.Ecommerce.Services.Customers
{
    public class CustomerInformationService : ICustomerInformationService
    {
        private readonly ICustomerInfoRepository _customerInfoRepository;
        public CustomerInformationService(ICustomerInfoRepository customerInfoRepository)
        {
            _customerInfoRepository = customerInfoRepository;
        }
        public Task<CustomerInformation> Create(CustomerInformationViewModel input)
        {
            return _customerInfoRepository.AddAsync(new CustomerInformation
            {
                RefrenceId = input.RefrenceId,
                Address1 = input.Address1,
                Address2 = input.Address2,
                Address3 = input.Address3,
                City = input.City,
                Email = input.Email,
                FirstName = input.FirstName,
                LastName = input.LastName,
                PhoneNumber = input.PhoneNumber,
                PostalCode = input.PostalCode
            });
        }

        public Task<CustomerInformationQueryResult> GetPaged(int take, int skip)
        {
            throw new NotImplementedException();
        }
    }
}
