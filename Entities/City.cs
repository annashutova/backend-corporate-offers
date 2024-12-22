using CorporateOffers.Data;
using Microsoft.EntityFrameworkCore;

namespace CorporateOffers.Entities;

public class City
{
    public int Id {get; init;}
    public string Name {get; init;}
    public List<Offer> Offers { get; } = [];

    public City(int id, string name) {
        Id = id;
        Name = name;
    }

    public static async Task<City?> GetByName(AppDbContext dbContext, string name, CancellationToken cancellationToken)
    {
        return await dbContext.Cities.FirstOrDefaultAsync(c => c.Name == name, cancellationToken);
    }
}