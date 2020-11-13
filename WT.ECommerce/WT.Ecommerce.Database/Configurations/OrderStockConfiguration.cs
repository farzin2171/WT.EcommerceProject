using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WT.Ecommerce.Domain.Models;

namespace WT.Ecommerce.Database.Configurations
{
    internal sealed class OrderStockConfiguration : IEntityTypeConfiguration<OrderStock>
    {
        public void Configure(EntityTypeBuilder<OrderStock> builder)
        {
            builder.ToTable("OrderStocks");
            builder.HasKey(x => new { x.OrderId, x.StockId });

        }
    }
}
