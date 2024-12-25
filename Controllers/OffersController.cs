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

    [Authorize]
    [HttpGet("active")]
    public async Task<IActionResult> GetActiveOffers(
        [FromQuery] string? city,
        [FromQuery] string? category,
        CancellationToken cancellationToken)
    {
        var offersQuery = _dbContext.Offers.AsQueryable();

        // Фильтрация по статусу
        offersQuery = offersQuery.Where(o => o.Status == Status.Active);

        // Фильтрация по категории, если она задана
        if (!string.IsNullOrEmpty(category))
        {
            offersQuery = offersQuery.Where(o => 
                o.Category != null && 
                o.Category.Name == category);
        }

        // Фильтрация по городу, если он задан
        if (!string.IsNullOrEmpty(city))
        {
            offersQuery = offersQuery.Where(o => 
                o.Cities.Any(c => c.Name == city));
        }

        var offers = await offersQuery
            .Include(o => o.Cities)
            .Include(o => o.Category)
            .ToListAsync(cancellationToken);

        return Ok(offers);
    }

    [Authorize(Policy = "AdminPolicy")]
    [HttpGet("draft")]
    public async Task<IActionResult> GetDraftOffers(
        [FromQuery] string? city,
        [FromQuery] string? category,
        CancellationToken cancellationToken)
    {
        var offersQuery = _dbContext.Offers.AsQueryable();

        // Фильтрация по статусу
        offersQuery = offersQuery.Where(o => o.Status == Status.Draft);

        // Фильтрация по категории, если она задана
        if (!string.IsNullOrEmpty(category))
        {
            offersQuery = offersQuery.Where(o => 
                o.Category != null && 
                o.Category.Name == category);
        }

        // Фильтрация по городу, если он задан
        if (!string.IsNullOrEmpty(city))
        {
            offersQuery = offersQuery.Where(o => 
                o.Cities.Any(c => c.Name == city));
        }

        var offers = await offersQuery
            .Include(o => o.Cities)
            .Include(o => o.Category)
            .ToListAsync(cancellationToken);

        return Ok(offers);
    }

    [Authorize(Policy = "AdminPolicy")]
    [HttpGet("archived")]
    public async Task<IActionResult> GetArchivedOffers(
        [FromQuery] string? city,
        [FromQuery] string? category,
        CancellationToken cancellationToken)
    {
        var offersQuery = _dbContext.Offers.AsQueryable();

        // Фильтрация по статусу
        offersQuery = offersQuery.Where(o => o.Status == Status.Archived);

        // Фильтрация по категории, если она задана
        if (!string.IsNullOrEmpty(category))
        {
            offersQuery = offersQuery.Where(o => 
                o.Category != null && 
                o.Category.Name == category);
        }

        // Фильтрация по городу, если он задан
        if (!string.IsNullOrEmpty(city))
        {
            offersQuery = offersQuery.Where(o => 
                o.Cities.Any(c => c.Name == city));
        }

        var offers = await offersQuery
            .Include(o => o.Cities)
            .Include(o => o.Category)
            .ToListAsync(cancellationToken);

        return Ok(offers);
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetOfferById(int id, CancellationToken cancellationToken)
    {
        // Поиск предложения по id
        var offer = await _dbContext.Offers
            .Include(o => o.Category)
            .Include(o => o.Cities)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        // Проверка, существует ли предложение
        if (offer == null)
        {
            return NotFound($"Предложение с id={id} не найдено");
        }

        return Ok(offer);
    }

    [Authorize(Policy = "AdminPolicy")]
    [HttpPost("")]
    public async Task<IActionResult> CreateOffer(
        [FromBody] CreateOfferData request,
        CancellationToken cancellationToken)
    {
        if (request.StartDate > request.EndDate)
        {
            return BadRequest(new { message = "Дата начала предложения не может быть больше даты окончания" });
        }

        // Проверяем статус предложения
        if (request.Status == Status.Archived)
        {
            return BadRequest(new { message = "Невозможно создать архивное предложение" });
        }

        // Проверяем и преобразуем в Enum тип предложения
        var offerTypeNotPresent = string.IsNullOrWhiteSpace(request.OfferType);
        var offerTypeIsValid = Enum.TryParse<OfferType>(request.OfferType, out var offerType);

        // Проверяем, если статус - Active
        if (request.Status == Status.Active)
        {
            if (string.IsNullOrWhiteSpace(request.Name) ||
                string.IsNullOrWhiteSpace(request.Annotation) ||
                string.IsNullOrWhiteSpace(request.CompanyUrl) ||
                string.IsNullOrWhiteSpace(request.Description) ||
                string.IsNullOrWhiteSpace(request.Category) ||
                string.IsNullOrWhiteSpace(request.ImagePath) ||
                request.StartDate == null ||
                request.EndDate == null ||
                request.Cities.Count == 0 ||
                offerTypeNotPresent)
            {
                return BadRequest(new { message = "Все поля обязательны для заполнения" });
            }
        }

        // Проверяем OfferType и DiscountSize
        if (!offerTypeNotPresent)
        {
            if (!offerTypeIsValid)
            {
                return BadRequest(new { message = $"Типа предложения со значением = {request.OfferType} не существует" });
            }
        
            switch (offerType)
            {
                case OfferType.Discount when request.DiscountSize is < 0 or > 100:
                    return BadRequest(new { message = "DiscountSize должен быть от 0 до 100" });
                case OfferType.Benefit when request.DiscountSize != null:
                    return BadRequest(new { message = "Для предложения типа Benefit нельзя указать размер скидки DiscountSize" });
            }
        }
        
        // Проверяем, существует ли категория в базе
        if (request.Category != null)
        {
            var categoryExists = await _dbContext.Categories
                .AnyAsync(c => c.Name == request.Category, cancellationToken);
            if (!categoryExists)
            {
                return BadRequest(new { message = $"Категории {request.Category} не существует" });
            }
        }

        // Получаем ID категории
        var category = request.Category != null ? await Category.GetByName(_dbContext, request.Category, cancellationToken) : null;
        int? categoryId = null;
        if (category != null) {
            categoryId = category.Id;
        }

        var cities = new List<City?>();
        if (request.Cities.Count > 0)
        {
            foreach (var cityName in request.Cities)
            {
                var city = await City.GetByName(_dbContext, cityName, cancellationToken);
                if (city != null)
                {
                    cities.Add(city);
                }
                else
                {
                    return BadRequest(new { message = "Один или несколько городов не существуют" });
                }
            }
        }

        // Создаем новое предложение
        var newOffer = new Offer
        (
            name: request.Name,
            annotation: request.Annotation,
            companyUrl: request.CompanyUrl,
            description: request.Description,
            startDate: request.StartDate?.ToUniversalTime(),
            endDate: request.EndDate?.ToUniversalTime(),
            offerType: offerType,
            status: request.Status,
            categoryId: categoryId,
            links: request.Links,
            imagePath: request.ImagePath,
            discountSize: request.DiscountSize
        );

        newOffer.Cities = cities;

        _dbContext.Offers.Add(newOffer);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(CreateOffer), new { id = newOffer.Id }, newOffer);
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
    
    [Authorize(Policy = "AdminPolicy")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> EditOffer(int id, EditOfferRequest request, CancellationToken cancellationToken)
    {
        // Проверяем на архивацию
        if (request.Status == Status.Archived)
        {
            return BadRequest(new { message = "Архивация предложения недоступна" });
        }
        
        if (request.StartDate > request.EndDate)
        {
            return BadRequest(new { message = "Дата начала предложения не может быть больше даты окончания" });
        }
        
        // Пытаемся найти предложение
        var offer = await _dbContext.Offers
            .Include(o => o.Cities)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        if (offer == null) return NotFound(new { message = $"Предложение с id={id} не найдено" });

        // Проверяем статус предложения
        if (offer.Status == Status.Archived)
        {
            return BadRequest(new { message = "Архивные предложения нельзя изменять" });
        }

        var offerTypeNotPresent = string.IsNullOrWhiteSpace(request.OfferType);
        var offerTypeIsValid = Enum.TryParse<OfferType>(request.OfferType, out var offerType);

        // Проверяем, если статус - Active
        if (request.Status == Status.Active)
        {
            if (string.IsNullOrWhiteSpace(request.Name) ||
                string.IsNullOrWhiteSpace(request.Annotation) ||
                string.IsNullOrWhiteSpace(request.CompanyUrl) ||
                string.IsNullOrWhiteSpace(request.Description) ||
                string.IsNullOrWhiteSpace(request.Category) ||
                string.IsNullOrWhiteSpace(request.ImagePath) ||
                request.StartDate == null ||
                request.EndDate == null ||
                request.Cities.Count == 0 ||
                offerTypeNotPresent)
            {
                return BadRequest(new { message = "Все поля обязательны для заполнения" });
            }
        }

        // Проверяем OfferType и DiscountSize
        if (!offerTypeNotPresent)
        {
            if (!offerTypeIsValid)
            {
                return BadRequest(new { message = $"Типа предложения со значением = {request.OfferType} не существует" });
            }
        
            switch (offerType)
            {
                case OfferType.Discount when request.DiscountSize is < 0 or > 100:
                    return BadRequest(new { message = "DiscountSize должен быть от 0 до 100" });
                case OfferType.Benefit when request.DiscountSize != null:
                    return BadRequest(new { message = "Для предложения типа Benefit нельзя указать размер скидки DiscountSize" });
            }
        }

        // Проверяем, существует ли категория в базе
        if (request.Category != null)
        {
            var categoryExists = await _dbContext.Categories
                .AnyAsync(c => c.Name == request.Category, cancellationToken);
            if (!categoryExists)
            {
                return BadRequest(new { message = $"Категория {request.Category} не существует" });
            }
        }

        var category = request.Category != null ? await Category.GetByName(_dbContext, request.Category, cancellationToken) : null;

        var cities = new List<City?>();
        foreach (var cityName in request.Cities)
        {
            var city = await City.GetByName(_dbContext, cityName, cancellationToken);
            if (city == null)
            {
                return BadRequest(new { message = $"Город {cityName} не существует" });
            }
            cities.Add(city);
        }

        var offerData = new EditOfferData(
            Name: request.Name,
            Annotation: request.Annotation,
            CompanyUrl: request.CompanyUrl,
            Description: request.Description,
            Status: request.Status,
            StartDate: request.StartDate?.ToUniversalTime(),
            EndDate: request.EndDate?.ToUniversalTime(),
            OfferType: offerType,
            DiscountSize: request.DiscountSize,
            Category: category,
            Links: request.Links ?? [],
            ImagePath: request.ImagePath,
            Cities: cities);

        await offer.ChangeOfferData(offerData, _dbContext, cancellationToken);

        return Ok(new { message = "Предложение успешно обновлено" });
    }
}
