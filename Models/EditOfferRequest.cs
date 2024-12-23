using System.Text.Json.Serialization;
using CorporateOffers.Entities;

namespace CorporateOffers.Models;

public record EditOfferRequest(
    string? Name,
    string? Annotation,
    string? CompanyUrl,
    string? Description,
    DateTime? StartDate,
    DateTime? EndDate,
    string? OfferType,
    int? DiscountSize,
    string? Category,
    List<string?> Links,
    string? ImagePath,
    List<string?> Cities)
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Status Status { get; init; }
}