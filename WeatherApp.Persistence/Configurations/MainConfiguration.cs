using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherApp.Domain.Entities;

namespace WeatherApp.Persistence.Configurations
{
    public class MainConfiguration : IEntityTypeConfiguration<Main>
    {
        public void Configure(EntityTypeBuilder<Main> builder)
        {
            builder.HasKey(p => p.MainId);
        }
    }
}