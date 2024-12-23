using System.ComponentModel.DataAnnotations.Schema;
using CorporateOffers.Utils;

namespace CorporateOffers.Entities;

public class City
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get; init;}
    public string Name {get; init;}
    public List<Offer> Offers { get; } = [];

    public City(string name) {
        Name = name;
    }
}