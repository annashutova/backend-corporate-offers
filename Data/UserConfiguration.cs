using CorporateOffers.Entities;
using CorporateOffers.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CorporateOffers.Data;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(p => p.Id);
        builder.HasIndex(p => p.Email).IsUnique();
        builder.Property(p => p.Email).IsRequired().HasMaxLength(50);
        builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);

        builder.Property(p => p.Password).IsRequired().HasMaxLength(32);

        builder.HasData(new User[] {
            new (1, "email@gmail.com", "Ivan", "Ivanov", Role.Admin, Hash.HashPassword("123")),
            new (2, "email", "Marina", "Ivanova", Role.Employee, Hash.HashPassword("123")),
        });
    }
}