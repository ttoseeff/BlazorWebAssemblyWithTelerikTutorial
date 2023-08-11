using BlazorProject.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorProject.Client.Services
{
    public interface IAuthorsService
    {
        Task<List<Author>> GetAllAuthors();
    }
}