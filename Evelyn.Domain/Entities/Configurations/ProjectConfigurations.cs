using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evelyn.Domain.Entities.Configurations
{
    public class ProjectConfigurations : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.DateOfProject).IsRequired();
            builder.Property(c => c.Status).IsRequired();
            builder.Property(c => c.Type).IsRequired();
            builder.Property(c => c.AddressId).IsRequired();
            builder.HasOne(c => c.Address);
            builder.HasMany(c => c.Products);
            builder.HasMany(c => c.UserProjects).WithOne(c => c.Project);
        }
    }
}
