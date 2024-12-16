using System.ComponentModel.DataAnnotations;

namespace CorporateOffers.Models;
public record Login (
    [Required] string Email, 
    [Required] string Password);