using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Domain.Entities;

namespace WeatherApp.Persistence.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasOne(m => m.Main)
                .WithOne(c => c.City)
                .HasForeignKey<Main>(fk => fk.CityId);

            builder.HasOne(w=>w.Wind)
                .WithOne(c => c.City)
                .HasForeignKey<Wind>(fk => fk.CityId);

            builder.HasOne(w => w.Weather)
               .WithOne(c => c.City)
               .HasForeignKey<Weather>(fk => fk.CityId);

        }
    }
}
