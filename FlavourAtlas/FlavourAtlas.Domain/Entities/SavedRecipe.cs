using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavourAtlas.Domain.Entities
{
    public class SavedRecipe
    {
        public Guid UserId { get; private set; }
        public User User { get; private set; } = default!;

        public Guid RecipeId { get; private set; }
        public Recipe Recipe { get; private set; } = default!;
    }
}
