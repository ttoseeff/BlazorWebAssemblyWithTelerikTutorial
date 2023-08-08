using BlazorProject.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorProject.Client.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly HttpClient client;

        public PublisherService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<Publishers>> GetPublishers()
        {
            try
            {

            return await client.GetFromJsonAsync<IEnumerable<Publishers>>("api/Publisher");
            }
            catch(Exception ex) 
            {
                return null;
            }
        }
        public async Task<Publishers> AddPublisher(Publishers publisher)
        {
            var response = await client.PostAsJsonAsync<Publishers>("api/Publisher", publisher);
            if (response != null)
            {
                var content = await response.Content.ReadAsStringAsync();
                var publisherData = JsonConvert.DeserializeObject<Publishers>(content);
                return publisherData;
            }
            return null;
        }

        public async Task DeletePublisher(int Id)
        {
            await client.DeleteAsync($"api/Publisher/{Id}");
        }

        public async Task<Publishers> UpdatePublisher(Publishers publisher)
        {
            var response =  await client.PutAsJsonAsync<Publishers>($"api/Publisher", publisher);
            if(response != null)
            {
                var content = await response.Content.ReadAsStringAsync();
                var publisherData = JsonConvert.DeserializeObject<Publishers>(content);
                return publisherData;
            }
            return null;
        }
    }
}
