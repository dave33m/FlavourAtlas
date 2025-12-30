using FlavourAtlas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlavourAtlas.Infrastructure.Persistence.Configurations;

public class SavedRecipeConfiguration : IEntityTypeConfiguration<SavedRecipe>
{
    public void Configure(EntityTypeBuilder<SavedRecipe> builder)
    {
        builder.HasKey(x => new { x.UserId, x.RecipeId });

        builder.HasOne(x => x.User)
               .WithMany(u => u.SavedRecipes)
               .HasForeignKey(x => x.UserId);

        builder.HasOne(x => x.Recipe)
               .WithMany()
               .HasForeignKey(x => x.RecipeId);
    }
}
