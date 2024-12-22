using CorporateOffers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CorporateOffers.Data;

public class OfferConfiguration : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder.ToTable("offers");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).HasMaxLength(50);
        builder.Property(p => p.Annotation).HasMaxLength(200);
        builder.Property(p => p.CompanyUrl).HasMaxLength(1000);
        builder.Property(p => p.StartDate);
        builder.Property(p => p.EndDate);
        
        builder.HasOne<Category>(p => p.Category)
            .WithMany(c => c.Offers)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasData(new Offer[] {
            new (1, "name", "annotation", "url", "description",
                DateTime.UtcNow, DateTime.UtcNow.Add(TimeSpan.FromDays(1)),
                OfferType.Benefit, Status.Active, 1, ["link1", "link2"]),
            new (2, "name2", "annotation2", "url2", "description2",
                DateTime.UtcNow, DateTime.UtcNow.Add(TimeSpan.FromDays(2)),
                OfferType.Discount, Status.Draft, 1, [], 10),
            new (3, null, "annotation3", null, "description3",
                DateTime.UtcNow, DateTime.UtcNow.Add(TimeSpan.FromDays(3)),
                OfferType.Discount, Status.Draft, 2, ["link3"], 10),
            new (4, "name4", "annotation4", "url4", "description4",
                DateTime.UtcNow.Add(TimeSpan.FromDays(1)), DateTime.UtcNow.Add(TimeSpan.FromDays(4)),
                OfferType.Benefit, Status.Archived, 1, ["link"]),
            new (5, "name5", "annotation5", "url5", "description5",
                DateTime.UtcNow.Add(TimeSpan.FromDays(2)), DateTime.UtcNow.Add(TimeSpan.FromDays(5)),
                OfferType.Benefit, Status.Active, 2, ["link"]),
        });
        
        builder.HasMany<City>(p => p.Cities)
            .WithMany(c => c.Offers)
            .UsingEntity(j =>
            {
                j.ToTable("cityToOffer");
                j.Property("CitiesId").HasColumnName("CityId");
                j.Property("OffersId").HasColumnName("OfferId");
                j.HasData(new[]
                {
                    new { OffersId = 1, CitiesId = 1 },
                    new { OffersId = 1, CitiesId = 2 },
                    new { OffersId = 1, CitiesId = 3 },
                    new { OffersId = 2, CitiesId = 1 },
                    new { OffersId = 2, CitiesId = 2 },
                    new { OffersId = 2, CitiesId = 4 },
                    new { OffersId = 3, CitiesId = 3 },
                    new { OffersId = 3, CitiesId = 4 },
                    new { OffersId = 4, CitiesId = 1 },
                    new { OffersId = 4, CitiesId = 3 },
                });
            });
    }
}