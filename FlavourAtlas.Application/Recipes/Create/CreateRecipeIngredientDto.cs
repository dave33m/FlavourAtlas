using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavourAtlas.Application.Recipes.Create
{
    public class CreateRecipeIngredientDto
    {
        public Guid IngredientId { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; } = default!;
    }
}
