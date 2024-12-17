using CorporateOffers.Utils;

namespace CorporateOffers.Entities;

public class Category
{
    public int Id {get; init;}
    public string Name {get; init;}
    public ICollection<Offer> Offers { get; } = new List<Offer>();

    public Category(int id, string name) {
        Id = id;
        Name = name;
    }
}