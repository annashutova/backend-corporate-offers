using CorporateOffers.Data;
using CorporateOffers.Entities;
using CorporateOffers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorporateOffers.Controllers;

[ApiController]
[Route("api/v1/offers")]
public class OffersController: ControllerBase
{
    private AppDbContext _dbContext;

    public OffersController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [Authorize(Policy = "AdminPolicy")]
    [HttpPut("archive/{id:int}")]
    public async Task<IActionResult> ArchiveOffer(int id, CancellationToken cancellationToken)
    {
        var offer = await _dbContext.Offers.FindAsync(id, cancellationToken);

        if (offer == null) return NotFound(new { message = $"Предложение с id={id} не найдено" });

        if (offer.Status == Status.Archived) return NoContent();

        await offer.ChangeOfferStatus(Status.Archived, _dbContext, cancellationToken);
        return Ok();
    }
}
