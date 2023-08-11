using BlazorProject.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorProject.Client.Services
{
    public interface IBookTypesService
    {
        Task<List<BookType>> GetAllBookTypes();
    }
}