using FlavourAtlas.Domain.Entities;

namespace FlavourAtlas.Application.Recipes;

public interface IRecipeRepository
{
    Task AddAsync(Recipe recipe, CancellationToken ct);
    Task<Recipe?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<IReadOnlyList<Recipe>> GetAllAsync(CancellationToken ct);
    Task SaveAsync(CancellationToken ct);
}
