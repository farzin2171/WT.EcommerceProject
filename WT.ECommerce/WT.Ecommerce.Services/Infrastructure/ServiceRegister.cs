namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection @this)
        {
            @this.AddTransient<WT.Ecommerce.Services.Customers.ICustomerInformationService,WT.Ecommerce.Services.Customers.CustomerInformationService>();
            @this.AddTransient<WT.Ecommerce.Database.Repositories.Interfaces.ICustomerInfoRepository, WT.Ecommerce.Database.Repositories.Database.CustomerInformationRepository>();



            return @this;
        }
    }
}
