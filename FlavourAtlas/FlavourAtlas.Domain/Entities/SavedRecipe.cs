namespace FlavourAtlas.Domain.Entities;

public class SavedRecipe
{
    public Guid UserId { get; private set; }
    public User User { get; private set; } = default!;

    public Guid RecipeId { get; private set; }
    public Recipe Recipe { get; private set; } = default!;

    private SavedRecipe() { } // EF

    public SavedRecipe(Guid userId, Guid recipeId)
    {
        UserId = userId;
        RecipeId = recipeId;
    }
}
