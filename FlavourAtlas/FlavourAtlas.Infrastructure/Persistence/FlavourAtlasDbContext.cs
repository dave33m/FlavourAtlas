using FlavourAtlas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlavourAtlas.Infrastructure.Persistence;

public class FlavourAtlasDbContext : DbContext
{
    public FlavourAtlasDbContext(DbContextOptions<FlavourAtlasDbContext> options)
        : base(options)
    {
    }

    public DbSet<Recipe> Recipes => Set<Recipe>();
    public DbSet<Ingredient> Ingredients => Set<Ingredient>();
    public DbSet<RecipeIngredient> RecipeIngredients => Set<RecipeIngredient>();
    public DbSet<SavedRecipe> SavedRecipes => Set<SavedRecipe>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FlavourAtlasDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
