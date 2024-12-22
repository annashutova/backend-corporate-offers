using CorporateOffers.Data;
using CorporateOffers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorporateOffers.Controllers;

[ApiController]
[Route("api/v1/cities")]
public class CitiesController: ControllerBase
{
    private AppDbContext _dbContext;

    public CitiesController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [Authorize]
    [HttpGet("")]
    public async Task<IActionResult> GetCities(CancellationToken cancellationToken)
    {
        var cities = await _dbContext.Cities.ToListAsync(cancellationToken);
        return Ok(new GetCitiesResponse(cities));
    }
}