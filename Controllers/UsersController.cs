using CorporateOffers.Data;
using CorporateOffers.Models;
using CorporateOffers.Services.AuthService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorporateOffers.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UsersController: ControllerBase
{
    private AppDbContext _dbContext;
    private JwtProvider _jwtProvider;

    public UsersController(AppDbContext dbContext, JwtProvider jwtProvider)
    {
        _dbContext = dbContext;
        _jwtProvider = jwtProvider;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(Login login, CancellationToken cancellationToken) 
    {
        var user = await _dbContext.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Email == login.Email, cancellationToken);
        
        if (user == null) {
            return NotFound();
        }

        if (!user.IsPasswordValid(login.Password)) {
            return Unauthorized();
        }

        var token = _jwtProvider.GenerateToken(user);
        return Ok(new LoginResult(token));
    }
}