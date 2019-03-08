using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherApp.Domain.Entities;

namespace WeatherApp.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(n => n.Name).IsRequired();
            builder.HasMany(r => r.UserRoles)
                .WithOne(r => r.Role)
                .HasForeignKey(fk => fk.RoleId);
        }
    }
}