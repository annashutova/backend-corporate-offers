using CorporateOffers.Utils;

namespace CorporateOffers.Entities;

public class Offer
{
    public int Id {get; init;}
    public string Name {get; init;}
    public string Annotation {get; init;}
    public string Company_url {get; init;}
    public string Description {get; init;}
    public DateTime Start_date {get; init;}
    public DateTime End_date {get; init;}
    public Offer_type Offer_type {get; init;}
    public int Discount_size {get; init;}
    public Status Status {get; init;}
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public List<CityOffer> CityOffers { get; } = [];
    public List<City> Cities { get; } = [];
    public Offer(int id, string name, string annotation, string company_url, string description, DateTime start_date, DateTime end_date, Offer_type offer_type, int discount_size, Status status, int categoryId) {
        Id = id;
        Name = name;
        Annotation = annotation;
        Company_url = company_url;
        Description = description;
        Start_date = start_date;
        End_date = end_date;
        Offer_type = offer_type;
        Discount_size = discount_size;
        Status = status;
        CategoryId = categoryId;
        Link = link;
        Image_path = image_path;
    }
}