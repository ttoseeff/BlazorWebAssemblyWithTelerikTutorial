using BlazorProject.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorProject.Server.Models
{
    public class BookTypesRepository : IBookTypesRepository
    {
        private readonly AppDbContext _Context;

        public BookTypesRepository(AppDbContext Context)
        {
            _Context = Context;
        }

        public async Task<List<BookType>> GetAllBookTypes()
        {
            return await _Context.BookTypes.ToListAsync();
        }
    }
}
