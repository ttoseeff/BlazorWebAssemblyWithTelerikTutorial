using BlazorProject.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorProject.Client.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly HttpClient httpClient;

        public AuthorsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Author>> GetAllAuthors()
        {
            return await httpClient.GetFromJsonAsync<List<Author>>("api/Authors");
        }
    }
}
