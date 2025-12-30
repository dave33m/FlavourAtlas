using FlavourAtlas.Application.Recipes.Create;
using FlavourAtlas.Application.Recipes;
using FlavourAtlas.Domain.Entities;
using FlavourAtlas.Infrastructure.Persistence;

namespace FlavourAtlas.Infrastructure.Repositories;

public class RegionRepository : IRegionRepository
{
    private readonly FlavourAtlasDbContext _db;

    public RegionRepository(FlavourAtlasDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync(Region region, CancellationToken ct)
    {
        _db.Regions.Add(region);
        await _db.SaveChangesAsync(ct);
    }
}
