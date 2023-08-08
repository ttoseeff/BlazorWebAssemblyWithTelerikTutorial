using BlazorProject.Server.Models;
using BlazorProject.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Policy;
using System.Threading.Tasks;

namespace BlazorProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepository publisherRepository;

        public PublisherController(IPublisherRepository publisherRepository)
        {
            this.publisherRepository = publisherRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllPublishers()
        {
            try
            {
                var pubs = await publisherRepository.GetAllPublishers();
                return Ok(pubs);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult> AddPublisher(Publishers publishers)
        {
            try
            {
                var publisher = await publisherRepository.CreatePublisher(publishers);
                return Ok(publisher);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletePublisher(int Id)
        {
            await publisherRepository.DeletePublisher(Id);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> UpdatePublisher(Publishers publisher)
        {
            var changedPublisher = await publisherRepository.UpdatePublisher(publisher);
            return Ok(changedPublisher);
        }
    }
}
