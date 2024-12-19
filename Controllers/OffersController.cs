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

    [Authorize]
    [HttpGet("")]
    public async Task<IActionResult> GetOffers(
        [FromQuery] string status,
        [FromQuery] string city,
        [FromQuery] string category,
        CancellationToken cancellationToken)
    {
        // Проверка валидности статуса
        if (status != 0 && status != 1 && status != 2)
        {
            return BadRequest("Invalid status parameter.");
        }
        // TODO доступ к archive и draft только у админов

        var offersQuery = _dbContext.Offers.AsQueryable();

        // Фильтрация по статусу
        offersQuery = offersQuery.Where(o => o.Status == status);

        // Фильтрация по городу, если он задан
        if (!string.IsNullOrEmpty(city))
        {
            offersQuery = offersQuery.Where(o => o.Cities.Any(c => c.Name == city));
        }

        // Фильтрация по категории, если она задана
        if (!string.IsNullOrEmpty(category))
        {
            offersQuery = offersQuery.Where(o => o.Category.Name == category);
        }

        var offers = await offersQuery.ToListAsync(cancellationToken);

        return Ok(offers);
    }

    [Authorize]
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

    [Authorize(Policy = "AdminPolicy")]
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
            (offerDto.Status != 0 && offerDto.Status != 1))
        {
            return BadRequest("Invalid status parameter.");
        }

        // преобразование дат в тип DateTime
        DateTime startDate;
        DateTime endDate;

        if (!DateTime.TryParse(offerDto.StartDate, out startDate))
        {
            return BadRequest("Invalid start date format.");
        }

        if (!DateTime.TryParse(offerDto.EndDate, out endDate))
        {
            return BadRequest("Invalid end date format.");
        }

        // получение ID категории по ее названию
        var categoryId = await _dbContext.Categories
            .Where(c => c.Name == offerDto.Category)
            .Select(c => c.Id)
            .FirstOrDefaultAsync(cancellationToken);

        // Создание нового предложения
        var newOffer = new Offer
        {
            Name = offerDto.Name,
            Annotation = offerDto.Annotation,
            CompanyUrl = offerDto.CompanyUrl,
            Description = offerDto.Description,
            StartDate = startDate,
            EndDate = endDate,
            OfferType = offerDto.OfferType,
            DiscountSize = offerDto.DiscountSize,
            Status = offerDto.Status,
            CategoryId = categoryId,
            Link = offerDto.Link,
            ImagePath = offerDto.ImagePath
        };

        _dbContext.Offers.Add(newOffer);

        // добавление городов к предложению
        foreach (var cityName in offerDto.Cities)
        {
            var city = await _dbContext.Cities
                .Where(c => c.Name == cityName)
                .FirstOrDefaultAsync(cancellationToken);

            newOffer.Cities.Add(city);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetOffers), new { id = newOffer.Id }, newOffer);
    }
}
