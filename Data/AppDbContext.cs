using CorporateOffers.Entities;
using Microsoft.EntityFrameworkCore;

namespace CorporateOffers.Data;

public class AppDbContext: DbContext
{
    public DbSet<TokenBlacklist> TokenBlacklist { get; set; }
    public required DbSet<User> Users {get; set;}
    public required DbSet<Offer> Offers {get; set;}
    public required DbSet<Category> Categories {get; set;}
    public required DbSet<City> Cities {get; set;}

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new TokenBlacklistConfiguration());
    }
}