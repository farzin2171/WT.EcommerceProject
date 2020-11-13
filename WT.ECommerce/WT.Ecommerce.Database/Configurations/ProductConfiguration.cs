using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WT.Ecommerce.Domain.Models;

namespace WT.Ecommerce.Database.Configurations
{
    internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.Property(u => u.Id).HasColumnName("Id");
            builder.Property(u => u.Name).HasMaxLength(512);
            builder.Property(u => u.Description).HasMaxLength(1024);
        }
    }
}
