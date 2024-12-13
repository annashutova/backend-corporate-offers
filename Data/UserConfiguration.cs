using CorporateOffers.Entities;
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
            new (1, "email@gmail.com", "Ivan", "Ivanov", Role.Admin, new byte[] {0xa6, 0x65, 0xa4, 0x59, 0x20, 0x42, 0x2f, 0x9d, 0x41, 0x7e, 0x48, 0x67, 0xef, 0xdc, 0x4f, 0xb8, 0xa0, 0x4a, 0x1f, 0x3f, 0xff, 0x1f, 0xa0, 0x7e, 0x99, 0x8e, 0x86, 0xf7, 0xf7, 0xa2, 0x7a, 0xe3}), // 123
        });
    }
}