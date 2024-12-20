using CorporateOffers.Data;

namespace CorporateOffers.Entities;

public class Offer
{
    public int Id {get; init;}
    public string? Name {get; private set;}
    public string? Annotation {get; private set;}
    public string? CompanyUrl {get; private set;}
    public string? Description {get; private set;}
    public DateTime? StartDate {get; private set;}
    public DateTime? EndDate {get; private set;}
    public OfferType? OfferType {get; private set;}
    public int? DiscountSize { get; private set; }
    public Status Status {get; private set;}
    public int? CategoryId { get; private set; }
    public Category? Category { get; private set; }
    public string? Link {get; private set;}
    public string? ImagePath {get; private set;}
    public List<City>? Cities { get; private set; } = [];
    public Offer(int id, string? name, string? annotation, string? companyUrl, string? description, DateTime? startDate, DateTime? endDate, OfferType? offerType, Status status, int? categoryId, string? link, string? imagePath, int? discountSize = null) {
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
    }

    public async Task ChangeOfferStatus(Status status, AppDbContext dbContext, CancellationToken cancellationToken)
    {
        Status = status;
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}