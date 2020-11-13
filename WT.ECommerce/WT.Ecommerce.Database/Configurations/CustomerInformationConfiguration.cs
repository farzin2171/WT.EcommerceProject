using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WT.Ecommerce.Domain.Models;

namespace WT.Ecommerce.Database.Configurations
{
    internal sealed class CustomerInformationConfiguration : IEntityTypeConfiguration<CustomerInformation>
    {
        public void Configure(EntityTypeBuilder<CustomerInformation> builder)
        {
            builder.ToTable("CustomerInformations");
            builder.Property(u => u.Id).HasColumnName("Id");
        }
    }
}
