using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherApp.Domain.Entities;

namespace WeatherApp.Persistence.Configurations
{
    public class WindConfiguration : IEntityTypeConfiguration<Wind>
    {
        public void Configure(EntityTypeBuilder<Wind> builder)
        {
            builder.HasKey(p => p.WindId);
        }
    }
}