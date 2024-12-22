using CorporateOffers.Data;
using CorporateOffers.Models;

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
    public List<string?> Links { get; private set; } = [];
    public List<City?> Cities { get; private set; } = [];
    public Offer(int id, string? name, string? annotation, string? companyUrl, string? description, DateTime? startDate, DateTime? endDate, OfferType? offerType, Status status, int? categoryId, List<string?> links, int? discountSize = null) {
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
        Links = links;
    }

    public async Task ChangeOfferStatus(Status status, AppDbContext dbContext, CancellationToken cancellationToken)
    {
        Status = status;
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task ChangeOfferData(EditOfferData offerData, AppDbContext dbContext, CancellationToken cancellationToken)
    {
        Name = offerData.Name;
        Annotation = offerData.Annotation;
        CompanyUrl = offerData.CompanyUrl;
        Description = offerData.Description;
        Status = offerData.Status;
        StartDate = offerData.StartDate;
        EndDate = offerData.EndDate;
        OfferType = offerData.OfferType;
        DiscountSize = offerData.DiscountSize;
        Category = offerData.Category;
        Links = offerData.Links ?? [];
        
        Cities.Clear();
        Cities.AddRange(offerData.Cities ?? []);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}