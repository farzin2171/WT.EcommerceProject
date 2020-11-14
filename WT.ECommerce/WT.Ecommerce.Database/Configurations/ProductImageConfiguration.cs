using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WT.Ecommerce.Domain.Models;

namespace WT.Ecommerce.Database.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImages");
            builder.Property(u => u.Id).HasColumnName("Id");
            builder.Property(u => u.Name).HasMaxLength(256);
            builder.Property(u => u.Description).HasMaxLength(1024);

        }
    }
}
