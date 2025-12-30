using FlavourAtlas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlavourAtlas.Infrastructure.Persistence.Configurations;

public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
{
    public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
    {
        builder.HasKey(x => new { x.RecipeId, x.IngredientId });

        builder.Property(x => x.Quantity)
               .IsRequired();

        builder.Property(x => x.Unit)
               .IsRequired()
               .HasMaxLength(50);

        builder.HasOne(x => x.Recipe)
               .WithMany(r => r.Ingredients)
               .HasForeignKey(x => x.RecipeId);

        builder.HasOne(x => x.Ingredient)
               .WithMany()
               .HasForeignKey(x => x.IngredientId);
    }
}
