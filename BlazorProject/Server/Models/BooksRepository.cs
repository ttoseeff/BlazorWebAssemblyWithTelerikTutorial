using BlazorProject.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Telerik.Blazor.Components.Stepper;

namespace BlazorProject.Server.Models
{
    public class BooksRepository : IBooksRepository
    {
        private readonly AppDbContext _Context;

        public BooksRepository(AppDbContext Context)
        {
            _Context = Context;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            var books = await _Context.Books.Include(x=> x.Author).Include(x=> x.BookType).ToListAsync();
            return books;
        }
        public async Task DeleteBook(int bookId)
        {
            var bookEntity = await _Context.Books.FirstOrDefaultAsync(x => x.Id == bookId);
            if (bookEntity != null)
            {
                _Context.Books.Remove(bookEntity);
                await _Context.SaveChangesAsync();
            }
        }

        public async Task UpdateBook(Book book)
        {
            var bookEntity = await _Context.Books.FirstOrDefaultAsync(x => x.Id == book.Id);
            if (bookEntity != null)
            {
                bookEntity.Title = book.Title;
                bookEntity.AuthorId = book.AuthorId;
                bookEntity.BookTypeId = book.BookTypeId;
                bookEntity.Sales = book.Sales;
                bookEntity.Price = book.Price;
                _Context.Entry(bookEntity).State = EntityState.Modified;
                await _Context.SaveChangesAsync();
            }
        }

        public async Task CreateBook(Book book)
        {
            await _Context.AddAsync(book);
            await _Context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetBooksByPage(int pageNumber, int pageSize)
        {
            var books =  await _Context.Books.OrderByDescending(x => x.Id)
                .Include(x => x.Author)
                .Include(x=> x.BookType)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return books;
        }
    }
}
