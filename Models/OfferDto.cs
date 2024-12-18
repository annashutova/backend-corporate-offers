using System.ComponentModel.DataAnnotations;

namespace CorporateOffers.Models;
public record OfferDto (
    [Required] string Name, 
    [Required] string Annotation,
    [Required] string Company_url, 
    [Required] string Description, 
    [Required] string Start_date, 
    [Required] string End_date, 
    [Required] string Offer_type, 
    [Required] string Discount_size, 
    [Required] string Status, 
    [Required] string CategoryId, 
    [Required] string Cities, 
);