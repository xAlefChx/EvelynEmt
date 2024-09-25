using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evelyn.Domain.Entities.Configurations
{
    public class UserProjectConfigurations : IEntityTypeConfiguration<UserProject>
    {
        public void Configure(EntityTypeBuilder<UserProject> builder)
        {
            builder.HasKey(up=> up.Id);
            builder.HasOne(up => up.User)
                   .WithMany(p => p.UserProjects)
                   .HasForeignKey(up => up.UserId);
            builder.HasOne(up => up.Project)
                .WithMany(p => p.UserProjects)
                .HasForeignKey(up => up.ProjectId);
        }
    }
}