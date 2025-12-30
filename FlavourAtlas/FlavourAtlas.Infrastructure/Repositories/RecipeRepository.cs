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

    public Task AddAsync(Recipe recipe, CancellationToken ct)
    {
        _db.Recipes.Add(recipe);
        return Task.CompletedTask;
    }


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
