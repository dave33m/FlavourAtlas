using FlavourAtlas.Domain.Entities;
using FlavourAtlas.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using FlavourAtlas.Application.Recipes.Create;
namespace FlavourAtlas.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegionsController : ControllerBase
{
    private readonly FlavourAtlasDbContext _db;

    public RegionsController(FlavourAtlasDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRegionDto request, CancellationToken ct)
    {
        var region = new Region(request.Name);

        _db.Regions.Add(region);
        await _db.SaveChangesAsync(ct);

        return CreatedAtAction(nameof(GetById), new { id = region.Id }, new { region.Id });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var region = await _db.Regions.FindAsync([id], ct);
        if (region == null) return NotFound();

        return Ok(region);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var regions = _db.Regions
            .OrderBy(r => r.Name)
            .Select(r => new
            {
                r.Id,
                r.Name
            })
            .ToList();

        return Ok(regions);
    }
}
