using CorporateOffers.Data;
using CorporateOffers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorporateOffers.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UsersController: ControllerBase
{
    private AppDbContext _dbContext;

    public UsersController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
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

        return Ok(new LoginResult("qwerty"));
    }
}