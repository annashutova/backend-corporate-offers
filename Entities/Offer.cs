using CorporateOffers.Utils;

namespace CorporateOffers.Entities;

public class Offer
{
    public int Id {get; init;}
    public string Name {get; init;}
    public string Annotation {get; init;}
    public string CompanyUrl {get; init;}
    public string Description {get; init;}
    public DateTime StartDate {get; init;}
    public DateTime EndDate {get; init;}
    public OfferType OfferType {get; init;}
    public int DiscountSize {get; init;}
    public Status Status {get; init;}
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public string Link {get; init;}
    public string ImagePath {get; init;}
    public List<CityOffer> CityOffers { get; } = [];
    public List<City> Cities { get; } = [];
    public Offer(int id, string name, string annotation, string companyUrl, string description, DateTime startDate, DateTime endDate, OfferType offerType, int discountSize, Status status, int categoryId, string link, string imagePath) {
        Id = id;
        Name = name;
        Annotation = annotation;
        CompanyUrl = companyUrl;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        OfferType = offerType;
        DiscountSize = discountSize;
        Status = status;
        CategoryId = categoryId;
        Link = link;
        ImagePath = imagePath;
        // cities
    }
}