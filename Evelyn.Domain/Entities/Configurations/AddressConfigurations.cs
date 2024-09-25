using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evelyn.Domain.Entities.Configurations
{
    public class AddressConfigurations : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.UserId).IsRequired();
            builder.Property(c => c.ProvinceId).IsRequired();
            builder.Property(c => c.CityId).IsRequired();
            builder.Property(c => c.MainAddress).IsRequired().HasMaxLength(512);
            builder.Property(c => c.ZipCode).IsRequired();
            builder.Property(c => c.Latitude).IsRequired().HasPrecision(9, 6);
            builder.Property(c => c.Longitude).IsRequired().HasPrecision(9, 6);
            builder.HasMany(c => c.Projects);
        }
    }
}