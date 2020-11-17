namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection @this)
        {
            @this.AddTransient<WT.Ecommerce.Services.Customers.ICustomerInformationService,WT.Ecommerce.Services.Customers.CustomerInformationService>();
            @this.AddTransient<WT.Ecommerce.Services.Products.IProductService, WT.Ecommerce.Services.Products.ProductService>();


            @this.AddTransient<WT.Ecommerce.Database.Repositories.Interfaces.ICustomerInfoRepository, WT.Ecommerce.Database.Repositories.Database.CustomerInformationRepository>();
            @this.AddTransient<WT.Ecommerce.Database.Repositories.Interfaces.IProductRepository, WT.Ecommerce.Database.Repositories.Database.ProductRepository>();
            @this.AddTransient<WT.Ecommerce.Database.Repositories.Interfaces.IProductImageRepository, WT.Ecommerce.Database.Repositories.Database.ProductImageRepository>();
            @this.AddTransient<WT.Ecommerce.Database.Repositories.Interfaces.IStockRepository, WT.Ecommerce.Database.Repositories.Database.StockRepository>();


            return @this;
        }
    }
}
