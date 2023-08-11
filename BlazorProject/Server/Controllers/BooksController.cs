using BlazorProject.Server.Models;
using BlazorProject.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlazorProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _BooksRepository;

        public BooksController(IBooksRepository BooksRepository)
        {
            this._BooksRepository = BooksRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllBooks()
        {
            return Ok(await _BooksRepository.GetAllBooks());
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBook(int bookId)
        {
            await _BooksRepository.DeleteBook(bookId);
            return Ok();
        }
        
        [HttpPut]
        public async Task<ActionResult> UpdateBook(Book book)
        {
            await _BooksRepository.UpdateBook(book);
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult> CreateBook(Book book)
        {
            await _BooksRepository.CreateBook(book);
            return Ok();
        }
        [HttpGet("GetBooksByPage")]
        public async Task<ActionResult> GetBooksByPage(int pageNumber, int pageSize)
        {
            return Ok(await _BooksRepository.GetBooksByPage(pageNumber, pageSize));
        }
    }
}
