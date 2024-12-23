using CorporateOffers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CorporateOffers.Data;

public class AppDbContext: DbContext
{
    public DbSet<TokenBlacklist> TokenBlacklist { get; set; }
    public required DbSet<User> Users {get; set;}
    public required DbSet<Category> Categories {get; set;}
    public required DbSet<City> Cities {get; set;}
    public required DbSet<Offer> Offers {get; set;}

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new TokenBlacklistConfiguration());
        
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new CityConfiguration());
        modelBuilder.ApplyConfiguration(new OfferConfiguration());

    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .ConfigureWarnings(w => 
                w.Ignore(RelationalEventId.PendingModelChangesWarning));
    }
}