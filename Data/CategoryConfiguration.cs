using CorporateOffers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CorporateOffers.Data;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("categories");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).HasMaxLength(50);
        builder.HasIndex(p => p.Name).IsUnique();



        builder.HasData(new Category[] {
            new (1, "Спорт"),
            new (2, "Отдых")
        });
    }
}