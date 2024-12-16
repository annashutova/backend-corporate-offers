using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CorporateOffers.Entities;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Extensions;

namespace CorporateOffers.Services.AuthService;

public class JwtProvider
{
    private readonly string _secretKey;
    private readonly int _expiresMinutes;

    public JwtProvider(IConfiguration configuration)
    {
        _secretKey = configuration["JWT_SECRET_KEY"] ?? "";
        var expiresMinutes = configuration["JWT_EXPIRES_MINUTES"];
        _expiresMinutes = !string.IsNullOrEmpty(expiresMinutes) ? int.Parse(expiresMinutes) : 12;
    }
    public string GenerateToken(User user)
    {
        Claim[] claims = [
            new Claim("id", user.Id.ToString()),
            new Claim("email", user.Email),
            new Claim("role", user.Role.GetDisplayName())
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
}