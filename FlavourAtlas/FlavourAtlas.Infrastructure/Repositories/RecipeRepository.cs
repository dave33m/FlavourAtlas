using FlavourAtlas.Application.Recipes;
using FlavourAtlas.Domain.Entities;
using FlavourAtlas.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FlavourAtlas.Infrastructure.Repositories;

public sealed class RecipeRepository : IRecipeRepository
{
    private readonly FlavourAtlasDbContext _db;

    public RecipeRepository(FlavourAtlasDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync(Recipe recipe, CancellationToken ct) =>
        await _db.Recipes.AddAsync(recipe, ct);

    public async Task SaveAsync(CancellationToken ct) =>
        await _db.SaveChangesAsync(ct);

    public async Task<IReadOnlyList<Recipe>> GetAllAsync(CancellationToken ct) =>
        await _db.Recipes
            .Include(r => r.Region)
            .Include(r => r.Ingredients)
                .ThenInclude(i => i.Ingredient)
            .AsNoTracking()
            .ToListAsync(ct);

    public async Task<Recipe?> GetByIdAsync(Guid id, CancellationToken ct) =>
        await _db.Recipes
            .Include(r => r.Region)
            .Include(r => r.Ingredients)
                .ThenInclude(i => i.Ingredient)
            .FirstOrDefaultAsync(r => r.Id == id, ct);
}
