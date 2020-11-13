using Microsoft.EntityFrameworkCore;
using WT.Ecommerce.Database.Infrastructure;


namespace WT.Ecommerce.Database
{
    internal sealed class ApplicationDbContextFactory : DesignTimeDbContextFactoryBase<ApplicationDbContext>
    {
        protected override ApplicationDbContext CreateNewInstance(DbContextOptions<ApplicationDbContext> options)
        {
            return new ApplicationDbContext(options);
        }
    }
}
