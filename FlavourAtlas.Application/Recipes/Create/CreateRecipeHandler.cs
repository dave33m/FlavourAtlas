using FlavourAtlas.Application.Recipes;
using FlavourAtlas.Domain.Entities;
using FlavourAtlas.Domain.Enums;

namespace FlavourAtlas.Application.Recipes.Create;

public class CreateRecipeHandler
{
    private readonly IRecipeRepository _recipes;

    public CreateRecipeHandler(IRecipeRepository recipes)
    {
        _recipes = recipes;
    }

    public async Task<Guid> Handle(CreateRecipeRequest request, CancellationToken ct)
    {
        var recipe = Recipe.Create(
            request.Name,
            (DifficultyLevel)request.Difficulty,
            request.PrepTimeMinutes,
            request.RegionId
        );

        foreach (var i in request.Ingredients)
        {
            recipe.AddIngredient(i.IngredientId, i.Quantity, i.Unit);
        }

        await _recipes.AddAsync(recipe, ct);
        await _recipes.SaveAsync(ct);

        return recipe.Id;
    }
}
