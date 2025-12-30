using FlavourAtlas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavourAtlas.Domain.Entities
{
    public class PlannedMeal
    {
        public Guid Id { get; private set; }

        public DayOfWeek Day { get; private set; }
        public MealType MealType { get; private set; }

        public Guid RecipeId { get; private set; }
        public Recipe Recipe { get; private set; } = default!;
    }
}
