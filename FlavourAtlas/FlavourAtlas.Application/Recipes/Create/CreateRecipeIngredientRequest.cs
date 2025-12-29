using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavourAtlas.Application.Recipes.Create
{
    public sealed record CreateRecipeIngredientRequest(
    Guid IngredientId,
    decimal Quantity,
    string Unit
);
}
