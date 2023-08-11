using BlazorProject.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorProject.Client.Services
{
    public interface IBooksService
    {
        Task<List<Book>> GetAllBooks();
        Task DeleteBook(int bookId);
        Task UpdateBook(Book book);
        Task CreateBook(Book book);
        Task<List<Book>> GetBooksByPage(int pageIndex, int pageSize);
    }
}