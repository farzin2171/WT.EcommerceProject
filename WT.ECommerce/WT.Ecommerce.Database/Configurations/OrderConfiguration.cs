using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WT.Ecommerce.Domain.Models;

namespace WT.Ecommerce.Database.Configurations
{
    internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.Property(u => u.Id).HasColumnName("Id");

        }
    }
}
