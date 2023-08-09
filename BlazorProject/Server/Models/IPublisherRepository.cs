using BlazorProject.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorProject.Server.Models
{
    public interface IPublisherRepository
    {
        Task<Publishers> CreatePublisher(Publishers publisher);
        Task<List<Publishers>> GetAllPublishers();
        Task DeletePublisher(int Id);
        Task<Publishers> UpdatePublisher(Publishers publisher);
        Task<List<Publishers>> GetPublishersByPage(int pageNumber, int pageSize);
    }
}