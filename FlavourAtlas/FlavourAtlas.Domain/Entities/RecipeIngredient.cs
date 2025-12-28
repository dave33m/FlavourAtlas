using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavourAtlas.Domain.Entities
{
    public class RecipeIngredient
    {
        public Guid RecipeId { get; private set; }
        public Recipe Recipe { get; private set; } = default!;

        public Guid IngredientId { get; private set; }
        public Ingredient Ingredient { get; private set; } = default!;

        public decimal Quantity { get; private set; }
        public string Unit { get; private set; } = default!;
    }
}
