using System.Text.Json.Serialization;
using CorporateOffers.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateOffers.Entities;

public class Category
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get; init;}
    public string Name {get; init;}
    [JsonIgnore]
    public List<Offer> Offers { get; } = [];

    public Category(string name) {
        Name = name;
    }

    public static async Task<Category?> GetByName(AppDbContext dbContext, string name, CancellationToken cancellationToken)
    {
        return await dbContext.Categories
            .FirstOrDefaultAsync(c => c.Name == name, cancellationToken);
    }
}