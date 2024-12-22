using System.ComponentModel.DataAnnotations;
using CorporateOffers.Entities;

namespace CorporateOffers.Models;
public record GetCitiesResponse ([Required] List<City?> Cities);