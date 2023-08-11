using BlazorProject.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorProject.Server.Models
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAuthors();
    }
}