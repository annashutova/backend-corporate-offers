using CorporateOffers.Data;
using CorporateOffers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorporateOffers.Controllers;

[ApiController]
[Route("api/v1/categories")]
public class CategoriesController: ControllerBase
{
    private AppDbContext _dbContext;

    public CategoriesController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [Authorize]
    [HttpGet("")]
    public async Task<IActionResult> GetCategories(CancellationToken cancellationToken)
    {
        var categories = await _dbContext.Categories.ToListAsync(cancellationToken);
        return Ok(new GetCategoriesResponse(categories));
    }
}