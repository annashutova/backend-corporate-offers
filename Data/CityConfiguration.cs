using CorporateOffers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CorporateOffers.Data;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("cities");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).HasMaxLength(50);
        builder.HasIndex(p => p.Name).IsUnique();


        builder.HasData(new City[] {
            new (1, "Москва"),
            new (2, "Санкт-Петербург"),
            new (3, "Иркутск"),
            new (4, "Новосибирск"),
        });
    }
}