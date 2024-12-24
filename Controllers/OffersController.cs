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
    [HttpGet("")]
    public async Task<IActionResult> GetOffers(
        [FromQuery] string status,
        [FromQuery] string city,
        [FromQuery] string category,
        CancellationToken cancellationToken)
    {
        // Проверка валидности статуса
        if (status != "Active" && status != "Draft" && status != "Archived")
        {
            return BadRequest("Неверный статус.");
        }
        // TODO доступ к archive и draft только у админов

        var offersQuery = _dbContext.Offers.AsQueryable();

        // Фильтрация по статусу
        Status statusEnum = (Status)Enum.Parse(typeof(Status), status);
        offersQuery = offersQuery.Where(o => o.Status == statusEnum);

        // Фильтрация по городу, если он задан
        if (!string.IsNullOrEmpty(city))
        {
            offersQuery = offersQuery.Where(o =>
                o.Cities != null &&
                o.Cities.Any(c => c.Name == city));
        }

        // Фильтрация по категории, если она задана
        if (!string.IsNullOrEmpty(category))
        {
            offersQuery = offersQuery.Where(o => 
                o.Category != null && 
                o.Category.Name == category);
        }

        var offers = await offersQuery.ToListAsync(cancellationToken);

        return Ok(offers);
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetOfferById(int id, CancellationToken cancellationToken)
    {
        // Поиск предложения по id
        var offer = await _dbContext.Offers.FindAsync([id], cancellationToken);

        // Проверка, существует ли предложение
        if (offer == null)
        {
            return NotFound($"Предложение с id={id} не найдено.");
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
            return BadRequest(new { message = "Дата начала предложения не может быть меньше даты окончания" });
        }

        // Проверяем статус предложения
        if (request.Status == Status.Archived)
        {
            return BadRequest(new { message = "Невозможно создать архивное предложение." });
        }

        // Проверяем и преобразуем в Enum тип предложения
        var offerTypeNotPresent = string.IsNullOrWhiteSpace(request.OfferType);
        var offerTypeIsValid = Enum.TryParse<OfferType>(request.OfferType, out var offerType);

        // Проверяем, если статус - Active
        if (request.Status == Status.Active)
        {
            // Проверяем тип предложения
            if (offerTypeNotPresent)
            {
                return BadRequest(new { message = "Все поля обязательны для заполнения" });
            }

            if (!offerTypeIsValid)
            {
                return BadRequest(new { message = $"Типа предложения со значением = {request.OfferType} не существует" });
            }
            
            if (string.IsNullOrWhiteSpace(request.Name) ||
                string.IsNullOrWhiteSpace(request.Annotation) ||
                string.IsNullOrWhiteSpace(request.CompanyUrl) ||
                string.IsNullOrWhiteSpace(request.Description) ||
                string.IsNullOrWhiteSpace(request.Category) ||
                string.IsNullOrWhiteSpace(request.ImagePath) ||
                request.StartDate == null ||
                request.EndDate == null ||
                request.Cities.Count == 0 ||
                (request.DiscountSize == null && offerType == OfferType.Discount) ||
                request.DiscountSize < 0 || request.DiscountSize > 100)
            {
                return BadRequest(new { message = "Все поля обязательны для заполнения, и DiscountSize должен быть от 0 до 100 для данного типа предложения" });
            }
        }

        // Проверяем OfferType и DiscountSize
        if (!offerTypeIsValid)
        {
            return BadRequest(new { message = $"Типа предложения со значением = {request.OfferType} не существует" });
        }
        
        if (offerType == OfferType.Discount && request.DiscountSize is < 0 or > 100)
        {
            return BadRequest(new { message = "DiscountSize должен быть от 0 до 100" });
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

        // Получаем ID категории
        var category = request.Category != null ? await Category.GetByName(_dbContext, request.Category, cancellationToken) : null;

        // Создаем нового предложения
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
            categoryId: category.Id,
            links: request.Links,
            imagePath: request.ImagePath,
            discountSize: request.DiscountSize
        );

        // Проверяем, существуют ли города в базе
        if (request.Cities.Count > 0)
        {
            var cityExists = await _dbContext.Cities
                .Where(city => request.Cities.Contains(city.Name))
                .AnyAsync(cancellationToken);
            if (!cityExists)
            {
                return BadRequest(new { message = "Один или несколько городов не существуют" });
            }
        }

        var cities = new List<City?>();
        foreach (var cityName in request.Cities)
        {
            var city = await City.GetByName(_dbContext, cityName, cancellationToken);
            if (city != null)
            {
                cities.Add(city);
            }
        }

        _dbContext.Offers.Add(newOffer);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetOffers), new { id = newOffer.Id }, newOffer);
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
            return BadRequest(new { message = "Дата начала предложения не может быть меньше даты окончания" });
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
            // Проверяем тип предлоения
            if (offerTypeNotPresent)
            {
                return BadRequest(new { message = "Все поля обязательны для заполнения" });
            }

            if (!offerTypeIsValid)
            {
                return BadRequest(new { message = $"Типа предложения со значением = {request.OfferType} не существует" });
            }
            
            if (string.IsNullOrWhiteSpace(request.Name) ||
                string.IsNullOrWhiteSpace(request.Annotation) ||
                string.IsNullOrWhiteSpace(request.CompanyUrl) ||
                string.IsNullOrWhiteSpace(request.Description) ||
                string.IsNullOrWhiteSpace(request.Category) ||
                string.IsNullOrWhiteSpace(request.ImagePath) ||
                request.StartDate == null ||
                request.EndDate == null ||
                request.Cities.Count == 0 ||
                (request.DiscountSize == null && offerType == OfferType.Discount) ||
                (request.DiscountSize < 0 || request.DiscountSize > 100))
            {
                return BadRequest(new { message = "Все поля обязательны для заполнения, и DiscountSize должен быть от 0 до 100 для данного типа предложения" });
            }
        }

        // Проверяем OfferType и DiscountSize
        if (!offerTypeIsValid)
        {
            return BadRequest(new { message = $"Типа предложения со значением = {request.OfferType} не существует" });
        }
        
        if (offerType == OfferType.Discount && request.DiscountSize is < 0 or > 100)
        {
            return BadRequest(new { message = "DiscountSize должен быть от 0 до 100" });
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
        
        // Проверяем, существуют ли города в базе
        if (request.Cities.Count > 0)
        {
            var cityExists = await _dbContext.Cities
                .Where(city => request.Cities.Contains(city.Name))
                .AnyAsync(cancellationToken);
            if (!cityExists)
            {
                return BadRequest(new { message = "Один или несколько городов не существуют" });
            }
        }

        var category = request.Category != null ? await Category.GetByName(_dbContext, request.Category, cancellationToken) : null;

        var cities = new List<City?>();
        foreach (var cityName in request.Cities)
        {
            var city = await City.GetByName(_dbContext, cityName, cancellationToken);
            if (city != null)
            {
                cities.Add(city);
            }
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
