using BlazorProject.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorProject.Client.Services
{
    public class CityService : ICityService
    {
        private readonly HttpClient client;

        public CityService(HttpClient client)
        {
            this.client = client;
        }
        public async Task<List<City>> GetCities()
        {
            return await client.GetFromJsonAsync<List<City>>("api/City");
        }
    }
}
