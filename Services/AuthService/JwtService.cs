using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CorporateOffers.Data;
using CorporateOffers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Extensions;

namespace CorporateOffers.Services.AuthService;

public class JwtService
{
    private readonly string _secretKey;
    private readonly int _expiresMinutes;
    private readonly AppDbContext _dbContext;

    public JwtService(IConfiguration configuration, AppDbContext dbContext)
    {
        _secretKey = configuration["JWT_SECRET_KEY"] ?? "";
        var expiresMinutes = configuration["JWT_EXPIRES_MINUTES"];
        _expiresMinutes = !string.IsNullOrEmpty(expiresMinutes) ? int.Parse(expiresMinutes) : 12;
        _dbContext = dbContext;
    }
    public string GenerateToken(User user)
    {
        Claim[] claims = [
            new Claim("id", user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.GetDisplayName())
        ];

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            signingCredentials: signingCredentials,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_expiresMinutes));

        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenValue;
    }

    private static DateTime GetTokenExpiration(string token)
    {
        var handler = new JwtSecurityTokenHandler();

        if (!handler.CanReadToken(token)) throw new ArgumentException("Invalid token");
        var jwtToken = handler.ReadJwtToken(token);
        var expiration = jwtToken.ValidTo;
        return expiration;

    }
    
    public async Task BlacklistTokenAsync(string token)
    {
        var tokenExpiration = GetTokenExpiration(token);
        var blacklistedToken = new TokenBlacklist
        {
            Token = token,
            Expiration = tokenExpiration
        };
        
        await _dbContext.TokenBlacklist.AddAsync(blacklistedToken);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsTokenBlacklistedAsync(string token)
    {
        return await _dbContext.TokenBlacklist
            .AnyAsync(bt => bt.Token == token);
    }
}