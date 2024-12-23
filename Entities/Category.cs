using System.ComponentModel.DataAnnotations.Schema;
using CorporateOffers.Utils;

namespace CorporateOffers.Entities;

public class Category
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get; init;}
    public string Name {get; init;}
    public List<Offer> Offers { get; } = [];

    public Category(string name) {
        Name = name;
    }
}