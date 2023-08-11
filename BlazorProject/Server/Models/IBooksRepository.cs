using BlazorProject.Client.Models.Teleril;
using BlazorProject.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorProject.Server.Models
{
    public interface IBooksRepository
    {
        Task<List<Book>> GetAllBooks();
        Task DeleteBook(int bookId);
        Task UpdateBook(Book book);
        Task CreateBook(Book book);
        Task<List<Book>> GetBooksByPage(int pageNumber, int pageSize, List<GridFilter> filters);
        Task<int> GetBooksByPageCount(int pageNumber, int pageSize, List<GridFilter> filters);
    }
}