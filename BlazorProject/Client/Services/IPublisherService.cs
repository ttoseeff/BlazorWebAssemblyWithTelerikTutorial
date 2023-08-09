using BlazorProject.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorProject.Client.Services
{
    public interface IPublisherService
    {
        Task<Publishers> AddPublisher(Publishers publisher);
        Task<IEnumerable<Publishers>> GetPublishers();
        Task DeletePublisher(int Id);
        Task<Publishers> UpdatePublisher(Publishers publisher);
        Task<List<Publishers>> GetPublishersByPage(int pageNumber, int pageSize);
    }
}