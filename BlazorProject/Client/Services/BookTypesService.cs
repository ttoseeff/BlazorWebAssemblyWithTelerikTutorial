using BlazorProject.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorProject.Client.Services
{
    public class BookTypesService : IBookTypesService
    {
        private readonly HttpClient _Client;

        public BookTypesService(HttpClient Client)
        {
            _Client = Client;
        }

        public async Task<List<BookType>> GetAllBookTypes()
        {
            return await _Client.GetFromJsonAsync<List<BookType>>("api/BookTypes");
        }
    }
}
