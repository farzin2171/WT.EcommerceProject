using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WT.Ecommerce.Domain.Models;

namespace WT.Ecommerce.Database.Configurations
{
    internal sealed class stockOnHoldConfiguration : IEntityTypeConfiguration<StockOnHold>
    {
        public void Configure(EntityTypeBuilder<StockOnHold> builder)
        {
            builder.ToTable("StockOnHold");
            builder.Property(u => u.Id).HasColumnName("Id");

        }
    }
}
