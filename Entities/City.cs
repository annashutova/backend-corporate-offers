using CorporateOffers.Utils;

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
}