using FlavourAtlas.Application.Recipes.Create;
using FlavourAtlas.Domain.Entities;
using FlavourAtlas.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace FlavourAtlas.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientsController : ControllerBase
{
    private readonly FlavourAtlasDbContext _db;

    public IngredientsController(FlavourAtlasDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateIngredientRequest request,
        CancellationToken ct)
    {
        var ingredient = new Ingredient(request.Name);

        _db.Ingredients.Add(ingredient);
        await _db.SaveChangesAsync(ct);

        return CreatedAtAction(
            nameof(GetById),
            new { id = ingredient.Id },
            new { ingredient.Id });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var ingredient = await _db.Ingredients.FindAsync(new object[] { id }, ct);
        if (ingredient == null)
            return NotFound();

        return Ok(ingredient);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var ingredients = _db.Ingredients
            .OrderBy(i => i.Name)
            .Select(i => new
            {
                i.Id,
                i.Name
            })
            .ToList();

        return Ok(ingredients);
    }
}
