using FlavourAtlas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavourAtlas.Domain.Entities
{
    public class Recipe
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; } = default!;
        public DifficultyLevel Difficulty { get; private set; }
        public int PrepTimeMinutes { get; private set; }

        public Guid RegionId { get; private set; }
        public Region Region { get; private set; } = default!;
    }
}
