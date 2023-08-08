using BlazorProject.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlazorProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllCities()
        {
            var cities = await cityRepository.GetAllCity();
            return Ok(cities);
        }
    }
}
