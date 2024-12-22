using System.Text.Json.Serialization;
using CorporateOffers.Data;
using Microsoft.EntityFrameworkCore;

namespace CorporateOffers.Entities;

public class Category
{
    public int Id {get; init;}
    public string Name {get; init;}
    [JsonIgnore]
    public List<Offer> Offers { get; } = [];

    public Category(int id, string name) {
        Id = id;
        Name = name;
    }

    public static async Task<Category?> GetByName(AppDbContext dbContext, string name, CancellationToken cancellationToken)
    {
        return await dbContext.Categories
            .FirstOrDefaultAsync(c => c.Name == name, cancellationToken);
    }
}