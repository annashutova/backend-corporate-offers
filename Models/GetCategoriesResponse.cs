using System.ComponentModel.DataAnnotations;
using CorporateOffers.Entities;

namespace CorporateOffers.Models;
public record GetCategoriesResponse ([Required] List<Category?> Categories);
