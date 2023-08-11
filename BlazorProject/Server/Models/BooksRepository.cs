using BlazorProject.Client.Models.Teleril;
using BlazorProject.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Telerik.Blazor.Components.Stepper;
using Telerik.DataSource;

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
            var books = await _Context.Books.Include(x => x.Author).Include(x => x.BookType).ToListAsync();
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

        public async Task<List<Book>> GetBooksByPage(int pageNumber, int pageSize, List<GridFilter> filters)
        {
            IQueryable<Book> books = _Context.Books.OrderByDescending(x => x.Id)
                .Include(x => x.Author)
                .Include(x => x.BookType);
                

            if (filters != null && filters.Count() > 0)
            {
                foreach (GridFilter filter in filters)
                {
                    if (filter.Member == nameof(Book.Title))
                    {
                        if (filter.Operator == FilterOperator.Contains)
                        {
                            books = books.Where(x => x.Title.Contains(filter.Value));
                        }
                    }
                    if (filter.Member == nameof(Book.Sales))
                    {
                        if (filter.Operator == FilterOperator.IsEqualTo)
                        {
                            if (!string.IsNullOrEmpty(filter.Value))
                                books = books.Where(x => x.Sales.Equals(Convert.ToDecimal(filter.Value)));
                        }
                    }

                }
            }

            return await books.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
        }

        public async Task<int> GetBooksByPageCount(int pageNumber, int pageSize, List<GridFilter> filters)
        {
            IQueryable<Book> books = _Context.Books.OrderByDescending(x => x.Id)
                .Include(x => x.Author)
                .Include(x => x.BookType);

            if (filters != null && filters.Count() > 0)
            {
                foreach (GridFilter filter in filters)
                {
                    if (filter.Member == nameof(Book.Title))
                    {
                        if (filter.Operator == FilterOperator.Contains)
                        {
                            books = books.Where(x => x.Title.Contains(filter.Value));
                        }
                    }
                    if (filter.Member == nameof(Book.Sales))
                    {
                        if (filter.Operator == FilterOperator.IsEqualTo)
                        {
                            if (!string.IsNullOrEmpty(filter.Value))
                                books = books.Where(x => x.Sales.Equals(Convert.ToDecimal(filter.Value)));
                        }
                    }

                }
            }

            return await books.CountAsync();
        }
    }
}
