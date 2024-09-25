using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evelyn.Domain.Entities.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ProjectId).IsRequired();
            builder.Property(c => c.ProductSerial).IsRequired().HasMaxLength(250);
            builder.Property(c => c.ProductModel).IsRequired().HasMaxLength(250);
            builder.Property(c => c.DateOfPurchase).IsRequired();
            builder.HasOne(c => c.Project);
        }
    }
}