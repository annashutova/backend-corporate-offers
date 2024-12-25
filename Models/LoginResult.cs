using CorporateOffers.Entities;

namespace CorporateOffers.Models;

public record LoginResult(
    string AccessToken,
    User User);