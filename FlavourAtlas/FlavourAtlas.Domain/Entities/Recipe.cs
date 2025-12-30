using FlavourAtlas.Domain.Enums;

namespace FlavourAtlas.Domain.Entities;

public class Recipe
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = default!;
    public DifficultyLevel Difficulty { get; private set; }
    public int PrepTimeMinutes { get; private set; }
    public Guid RegionId { get; private set; }
    public Region Region { get; private set; } = default!;
    public ICollection<RecipeIngredient> Ingredients { get; private set; }
        = new List<RecipeIngredient>();

    public static Recipe Create(
        string name,
        DifficultyLevel difficulty,
        int prepTimeMinutes,
        Guid regionId)
    {
        return new Recipe
        {
            Id = Guid.NewGuid(),
            Name = name,
            Difficulty = difficulty,
            PrepTimeMinutes = prepTimeMinutes,
            RegionId = regionId
        };
    }

    public void AddIngredient(Guid ingredientId, decimal quantity, string unit)
    {
        Ingredients.Add(new RecipeIngredient(ingredientId, quantity, unit));
    }
}
