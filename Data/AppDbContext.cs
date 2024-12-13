using CorporateOffers.Entities;
using Microsoft.EntityFrameworkCore;

namespace CorporateOffers.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        // Database.EnsureCreated();
    }
    public required DbSet<User> Users {get; set;}

}