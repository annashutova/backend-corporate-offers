using CorporateOffers.Entities;
using Microsoft.EntityFrameworkCore;

namespace CorporateOffers.Data;

public class AppDbContext: DbContext
{
    public DbSet<TokenBlacklist> TokenBlacklist { get; set; }
    public required DbSet<User> Users {get; set;}
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new TokenBlacklistConfiguration());
    }
}