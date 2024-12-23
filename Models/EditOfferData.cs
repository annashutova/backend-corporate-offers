using System.ComponentModel.DataAnnotations;
using CorporateOffers.Entities;

namespace CorporateOffers.Models;

public record EditOfferData(
    string? Name,
    string? Annotation,
    string? CompanyUrl,
    string? Description,
    [Required]
    Status Status,
    DateTime? StartDate,
    DateTime? EndDate,
    OfferType? OfferType,
    int? DiscountSize,
    Category? Category,
    List<string?> Links,
    string? ImagePath,
    List<City?> Cities);