using CorporateOffers.Data;
using CorporateOffers.Models;
using CorporateOffers.Services.AuthService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorporateOffers.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UsersController: ControllerBase
{
    private AppDbContext _dbContext;
    private JwtService _jwtService;

    public UsersController(AppDbContext dbContext, JwtService jwtService)
    {
        _dbContext = dbContext;
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(Login login, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Email == login.Email, cancellationToken);
        
        if (user == null) {
            return Unauthorized();
        }

        if (!user.IsPasswordValid(login.Password)) {
            return Unauthorized();
        }

        var token = _jwtService.GenerateToken(user);
        return Ok(new LoginResult(token));
    }
    
    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        var token = HttpContext.Request.Headers.Authorization.ToString().Replace("Bearer ", "");

        await _jwtService.BlacklistTokenAsync(token);
        
        return Ok();
    }
    
    [Authorize(Policy = "AdminPolicy")]
    [HttpGet("get_all")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var users = await _dbContext.Users.ToListAsync(cancellationToken);

        return Ok(users);
    }
    
}