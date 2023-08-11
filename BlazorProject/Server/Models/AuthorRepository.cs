using BlazorProject.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorProject.Server.Models
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _Context;

        public AuthorRepository(AppDbContext Context)
        {
            _Context = Context;
        }
        public async Task<List<Author>> GetAllAuthors()
        {
            return await _Context.Authors.ToListAsync();
        }
    }
}
