using Microsoft.AspNetCore.Mvc;
using FlavourAtlas.Application.Recipes.Create;

namespace FlavourAtlas.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateRecipe(
        [FromBody] CreateRecipeRequest request,
        [FromServices] CreateRecipeHandler handler,
        CancellationToken ct)
    {
        var id = await handler.Handle(request, ct);
        return CreatedAtAction(nameof(GetRecipeById), new { id }, null);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetRecipeById(Guid id)
    {
        return Ok();
    }

    [HttpGet]
    public IActionResult GetRecipes()
    {
        return Ok();
    }
}
