using BlazorProject.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Models
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext context;

        public CityRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<List<City>> GetAllCity()
        {
            return await context.Cities.ToListAsync();
        }
    }
}
