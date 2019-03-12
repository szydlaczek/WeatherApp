using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WeatherApp.Domain.Entities;

namespace WeatherApp.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasMany(r => r.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(fk => fk.UserId);

            builder.HasData(new User
            {
                Email = "szydlak@gmail.com",
                Id = Guid.NewGuid().ToString(),
                Password = "AQAAAAEAACcQAAAAEFW6zz2ufQ2jEvYA45ZIRW9Rc2I2t7kkUuwB5LucJRIxw6ayI+5isC9i9XIkd+M5rw==", //123456
                UserName = "szydlo.grzegorz"
            }); 
            
        }
    }
}