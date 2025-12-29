using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavourAtlas.Application.Recipes.Create
{
    public sealed record CreateRecipeRequest(
     string Name,
     int Difficulty,
     int PrepTimeMinutes,
     Guid RegionId,
     IReadOnlyList<CreateRecipeIngredientRequest> Ingredients
 );
}
