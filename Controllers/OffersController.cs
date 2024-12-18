using CorporateOffers.Data;
using CorporateOffers.Models;
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

    [HttpGet("")]
    public async Task<IActionResult> GetOffers(
        [FromQuery] string status,
        [FromQuery] string city,
        [FromQuery] string category,
        CancellationToken cancellationToken)
    {
        // Проверка валидности статуса
        if (status != "active" && status != "draft" && status != "archived")
        {
            return BadRequest("Invalid status parameter. Allowed values are: active, draft, archived.");
        }

        var offersQuery = _dbContext.Offers.AsQueryable();

        // Фильтрация по статусу
        offersQuery = offersQuery.Where(o => o.Status == status);

        // Фильтрация по городу, если он задан
        if (!string.IsNullOrEmpty(city))
        {
            offersQuery = offersQuery.Where(o => o.City == city);
        }

        // Фильтрация по категории, если она задана
        if (!string.IsNullOrEmpty(category))
        {
            offersQuery = offersQuery.Where(o => o.Category == category);
        }

        var offers = await offersQuery.ToListAsync(cancellationToken);

        return Ok(offers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOfferById(int id, CancellationToken cancellationToken)
    {
        // Поиск предложения по id
        var offer = await _dbContext.Offers.FindAsync(new object[] { id }, cancellationToken);

        // Проверка, существует ли предложение
        if (offer == null)
        {
            return NotFound($"Offer with ID {id} not found.");
        }

        return Ok(offer);
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateOffer(
        [FromBody] OfferDto offerDto,
        CancellationToken cancellationToken)
    {
        // Проверка на валидность входных данных
        if (offerDto == null)
        {
            return BadRequest("Offer data is required.");
        }

        if (string.IsNullOrEmpty(offerDto.Status) ||
            (offerDto.Status != "active" && offerDto.Status != "draft" && offerDto.Status != "archived"))
        {
            return BadRequest("Invalid status parameter. Allowed values are: active, draft, archived.");
        }

        // Создание нового предложения
        var newOffer = new Offer
        {
            Name = offerDto.Name,
            Annotation = offerDto.Annotation,
            CompanyUrl = offerDto.CompanyUrl,
            Description = offerDto.Description,
            StartDate = offerDto.StartDate,
            EndDate = offerDto.EndDate,
            OfferType = offerDto.OfferType,
            DiscountSize = offerDto.DiscountSize,
            Status = offerDto.Status,
            CategoryId = offerDto.CategoryId,
            Link = offerDto.Link,
            ImagePath = offerDto.ImagePath
        };
        // TODO заполнить city_to_offer

        _dbContext.Offers.Add(newOffer);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetOffers), new { id = newOffer.Id }, newOffer);
    }
}
