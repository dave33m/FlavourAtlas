using FlavourAtlas.Application.Recipes.Create;
using FlavourAtlas.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlavourAtlas.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly FlavourAtlasDbContext _db;

    public RecipesController(FlavourAtlasDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRecipe(
        [FromBody] CreateRecipeRequest request,
        [FromServices] CreateRecipeHandler handler,
        CancellationToken ct)
    {
        var id = await handler.Handle(request, ct);

        return CreatedAtAction(
            nameof(GetRecipeById),
            new { id },
            new
            {
                message = "Recipe created successfully",
                recipeId = id
            });
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetRecipeById(Guid id)
    {
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var recipes = await _db.Recipes
            .AsNoTracking()
            .Include(r => r.Region)
            .Include(r => r.Ingredients)
                .ThenInclude(ri => ri.Ingredient)
            .OrderByDescending(r => r.Id)
            .Select(r => new
            {
                r.Id,
                r.Name,
                r.Difficulty,
                r.PrepTimeMinutes,
                Region = new
                {
                    r.Region.Id,
                    r.Region.Name
                },
                Ingredients = r.Ingredients.Select(i => new
                {
                    i.IngredientId,
                    i.Ingredient.Name,
                    i.Quantity,
                    i.Unit
                })
            })
            .ToListAsync(ct);

        return Ok(recipes);
    }
}
