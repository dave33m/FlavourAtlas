using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavourAtlas.Application.DTOs
{
    public sealed record RecipeIngredientDto(
    string Name,
    decimal Quantity,
    string Unit
);
}
