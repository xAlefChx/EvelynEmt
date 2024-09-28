using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evelyn.Domain.Entities.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.ParentUserId).IsRequired(false);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
        builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(11);
        builder.Property(c => c.CoinScore).IsRequired();
        builder.Property(c => c.Role).IsRequired();
        builder.HasMany(c => c.Addresses).WithOne(a => a.User)
               .HasForeignKey(a => a.UserId)
               .OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(c => c.UserProjects).WithOne(c => c.User);
    }
}