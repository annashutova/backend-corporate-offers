using CorporateOffers.Utils;

namespace CorporateOffers.Entities;

public class Category
{
    public int Id {get; init;}
    public string Name {get; init;}
    public List<Offer> Offers { get; } = [];

    public Category(int id, string name) {
        Id = id;
        Name = name;
    }
}