using System.ComponentModel.DataAnnotations;

namespace CorporateOffers.Models;
public record OfferDto (
    [Required] string Name, 
    [Required] string Annotation,
    [Required] string CompanyUrl, 
    [Required] string Description, 
    [Required] DateTime StartDate, 
    [Required] DateTime EndDate, 
    [Required] OfferType OfferType, 
    [Required] int DiscountSize, 
    [Required] Status Status,
    [Required] string Category, 
    [Required] string Link, 
    [Required] string ImagePath, 
    [Required] List<string> Cities
);