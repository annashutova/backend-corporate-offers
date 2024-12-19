using CorporateOffers.Utils;

namespace CorporateOffers.Entities;

public class Offer
{
    public int Id {get; init;}
    public string Name {get; set;}
    public string Annotation {get; set;}
    public string CompanyUrl {get; set;}
    public string Description {get; set;}
    public DateTime StartDate {get; set;}
    public DateTime EndDate {get; set;}
    public OfferType OfferType {get; set;}
    public int DiscountSize {get; set;}
    public Status Status {get; set;}
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public string Link {get; set;}
    public string ImagePath {get; set;}
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
        // TODO cities
    }
}