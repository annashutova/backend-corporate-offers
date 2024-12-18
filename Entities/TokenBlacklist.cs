namespace CorporateOffers.Entities;

public class TokenBlacklist
{
    public int Id {get; init;}
    public string Token { get; init; }
    public DateTime Expiration { get; init; }
}