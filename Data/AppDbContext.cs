using CorporateOffers.Entities;
using Microsoft.EntityFrameworkCore;

namespace CorporateOffers.Data;

public class AppDbContext: DbContext
{
    public required DbSet<User> Users {get; set;}
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}