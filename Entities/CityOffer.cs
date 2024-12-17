using CorporateOffers.Utils;

namespace CorporateOffers.Entities;

public class CityOffer
{
    public int CitiesId { get; set; }
    public int OffersId { get; set; }
    public City City { get; set; } = null!;
    public Offer Offer { get; set; } = null!;

    public CityOffer(int citiesId, int offersId) {
        CitiesId = citiesId;
        OffersId = offersId;
    }
}