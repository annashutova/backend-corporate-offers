using System.ComponentModel.DataAnnotations;

namespace CorporateOffers.Models;
public record OfferDto (
    [Required] string? Name, 
    [Required] string? Annotation,
    [Required] string? CompanyUrl, 
    [Required] string? Description, 
    [Required] string? StartDate, 
    [Required] string? EndDate, 
    [Required] string? OfferType, 
    [Required] int? DiscountSize, 
    [Required] string Status,
    [Required] List<string?> Links,
    [Required] string? ImagePath, 
    [Required] string? Category, 
    [Required] List<string?> Cities
);