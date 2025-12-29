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
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<RecipeIngredient>(entity =>
        {
            entity.HasKey(x => new { x.RecipeId, x.IngredientId });

            entity.HasOne(x => x.Recipe)
                .WithMany(r => r.Ingredients)
                .HasForeignKey(x => x.RecipeId);

            entity.HasOne(x => x.Ingredient)
                .WithMany()
                .HasForeignKey(x => x.IngredientId);
        });
        modelBuilder.Entity<SavedRecipe>(entity =>
        {
            entity.HasKey(x => new { x.UserId, x.RecipeId });

            entity.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            entity.HasOne(x => x.Recipe)
                .WithMany()
                .HasForeignKey(x => x.RecipeId);
        });

    }

}
