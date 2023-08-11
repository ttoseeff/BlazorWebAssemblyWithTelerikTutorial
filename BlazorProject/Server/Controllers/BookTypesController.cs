using BlazorProject.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlazorProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookTypesController : ControllerBase
    {
        private readonly IBookTypesRepository BookTypesRepository;

        public BookTypesController(IBookTypesRepository bookTypesRepository)
        {
            BookTypesRepository = bookTypesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookTypes() 
        {
            return Ok(await BookTypesRepository.GetAllBookTypes());
        }
    }
}
