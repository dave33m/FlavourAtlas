using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavourAtlas.Application.DTOs
{
    public sealed record RecipeDto(
    Guid Id,
    string Name,
    string Difficulty,
    int PrepTimeMinutes,
    string Region,
    IReadOnlyList<RecipeIngredientDto> Ingredients
);
}
