using FlavourAtlas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavourAtlas.Application.Recipes
{
    public interface IRegionRepository
    {
        Task AddAsync(Region region, CancellationToken ct);
    }
}
