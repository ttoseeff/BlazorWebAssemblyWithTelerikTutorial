using BlazorProject.Client.Models.Teleril;
using BlazorProject.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorProject.Client.Services
{
    public class BooksService : IBooksService
    {
        private readonly HttpClient _Client;

        public BooksService(HttpClient Client)
        {
            _Client = Client;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            var response = await _Client.GetFromJsonAsync<List<Book>>("api/Books");
            return response;
        }

        public async Task DeleteBook(int bookId)
        {
            await _Client.DeleteAsync($"api/Books?bookId={bookId}");
        }

        public async Task UpdateBook(Book book)
        {
            await _Client.PutAsJsonAsync($"api/Books", book);
        }

        public async Task CreateBook(Book book)
        {
            await _Client.PostAsJsonAsync($"api/Books", book);
        }

        public async Task<List<Book>> GetBooksByPage(int pageIndex, int pageSize, List<GridFilter> filters)
        {
            var response = await _Client.PostAsJsonAsync($"api/Books/GetBooksByPage?pageNumber={pageIndex}&pageSize={pageSize}", filters);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var books = JsonConvert.DeserializeObject<List<Book>>(content);
            return books;
        }

        public async Task<int> GetBooksByPageCount(int pageIndex, int pageSize, List<GridFilter> filters)
        {
            var response = await _Client.PostAsJsonAsync($"api/Books/GetBooksByPageCount?pageNumber={pageIndex}&pageSize={pageSize}", filters);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var books = JsonConvert.DeserializeObject<int>(content);
            return books;
        }
    }
}
