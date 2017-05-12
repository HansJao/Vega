using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.Models;
using Vega.Persistence;

namespace Vega.Controllers
{
    public class FeaturesController
    {
        private readonly VegaDbContext context;
        public FeaturesController(VegaDbContext context)
        {
            this.context = context;
        }
         [HttpGet("/api/Features")]
        public async Task<IEnumerable<Feature>> GetMakes()
        {
            return await context.Features.ToListAsync();
        }
    }
}