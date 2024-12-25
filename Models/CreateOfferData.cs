using System.Text.Json.Serialization;
using CorporateOffers.Entities;

namespace CorporateOffers.Models;

public record CreateOfferData (
    string? Name, 
    string? Annotation,
    string? CompanyUrl, 
    string? Description, 
    DateTime? StartDate, 
    DateTime? EndDate, 
    string? OfferType, 
    int? DiscountSize, 
    List<string?> Links,
    string? ImagePath, 
    string? Category, 
    List<string>? Cities
)
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Status Status { get; init; }
}