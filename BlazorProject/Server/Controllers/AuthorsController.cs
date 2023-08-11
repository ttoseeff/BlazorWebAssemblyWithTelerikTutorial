using BlazorProject.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlazorProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllAuthors()
        {
            return Ok(await authorRepository.GetAllAuthors());
        }
    }
}
