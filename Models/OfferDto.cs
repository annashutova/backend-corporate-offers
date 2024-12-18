using System.ComponentModel.DataAnnotations;

namespace CorporateOffers.Models;
public record OfferDto (
    [Required] string Name, 
    [Required] string Annotation,
    [Required] string CompanyUrl, 
    [Required] string Description, 
    [Required] string StartDate, 
    [Required] string EndDate, 
    [Required] string OfferType, 
    [Required] string DiscountSize, 
    [Required] string Status, 
    [Required] string CategoryId, 
    [Required] string Cities, 
);