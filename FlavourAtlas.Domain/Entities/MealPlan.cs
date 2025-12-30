using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavourAtlas.Domain.Entities
{
    public class MealPlan
    {
        public Guid Id { get; private set; }

        public Guid UserId { get; private set; }

        public DateOnly WeekStartDate { get; private set; }

        public ICollection<PlannedMeal> Meals { get; private set; } = new List<PlannedMeal>();
    }
}
