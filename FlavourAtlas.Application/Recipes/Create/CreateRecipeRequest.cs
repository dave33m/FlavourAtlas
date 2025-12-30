using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavourAtlas.Application.Recipes.Create
{
    public class CreateRecipeRequest
    {
        public string Name { get; set; } = null!;
        public int Difficulty { get; set; }
        public int PrepTimeMinutes { get; set; }

        public Guid RegionId { get; set; }
        public List<CreateRecipeIngredientDto> Ingredients { get; set; } = new();
    }

}
