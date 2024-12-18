using CorporateOffers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CorporateOffers.Data;

public class TokenBlacklistConfiguration : IEntityTypeConfiguration<TokenBlacklist>
{
    public void Configure(EntityTypeBuilder<TokenBlacklist> builder)
    {
        builder.ToTable("tokenBlacklist");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Token).IsRequired().HasMaxLength(512);;
        builder.Property(p => p.Expiration).IsRequired();
    }
}