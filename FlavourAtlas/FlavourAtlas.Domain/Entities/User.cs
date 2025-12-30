using FlavourAtlas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavourAtlas.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }

        public DietType DietType { get; private set; }

        public ICollection<SavedRecipe> SavedRecipes { get; private set; } = new List<SavedRecipe>();
    }
}
