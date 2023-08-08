using BlazorProject.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorProject.Server.Models
{
    public interface ICityRepository
    {
        Task<List<City>> GetAllCity();
    }
}