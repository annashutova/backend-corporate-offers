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
        builder.Property(p => p.Link).HasMaxLength(1000);
        builder.Property(p => p.ImagePath).HasMaxLength(200);
        
        builder.HasOne<Category>(p => p.Category)
            .WithMany(c => c.Offers)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany<City>(p => p.Cities)
            .WithMany(c => c.Offers)
            .UsingEntity(j => j.ToTable("cityToOffer"));

        builder.HasData(new Offer[] {
            new (1, "name", "annotation", "url", "description", DateTime.UtcNow, DateTime.UtcNow.Add(TimeSpan.FromDays(1)),
                OfferType.Benefit, Status.Active, 1, "link", "imagePath"),
        });
    }
}