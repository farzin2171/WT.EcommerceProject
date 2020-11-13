using Microsoft.EntityFrameworkCore;
using WT.Ecommerce.Database.Extentions;
using WT.Ecommerce.Domain.Models;

namespace WT.Ecommerce.Database
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Stock> Stoks { get; set; }
        public DbSet<OrderStock> OrderStocks { get; set; }
        public DbSet<StockOnHold> stockOnHolds { get; set; }
        public DbSet<CustomerInformation> customerInformation { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Search all Configurations and apply them 
            builder.ApplyAllConfigurations();
            base.OnModelCreating(builder);
        }

    }
}
